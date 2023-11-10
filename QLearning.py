import numpy as np
from matplotlib import pyplot as plt

UP = 0
RIGHT = 1
DOWN = 2
LEFT = 3

class Maze_ENV():
    def __init__(self, map): #constructor
        self.map = map
        self.y_max = map.shape[1]
        self.x_max = map.shape[0]
        self.current_pos = (3, 4)
        self.further_pos = (0, 0)
        self.nS = map.shape[0] * map.shape[1]
        self.nA = 4
        self.terminal_state = (0, 0)
        self.current_state = 0
        self.nearest = []
        self.itter = 0
        self.it = 0
        self.damaged = False
        self.walled = False

    # This function checks If next state is in boundary of table or not.
    def check_boundaries(self, pos):
        j = pos[0]
        i = pos[1]
        temp = True
        if i not in range(5) or j not in range(4):
            self.walled = True
            temp = False
        if self.current_pos[0] == 0 and self.current_pos[1] == 1 and j == 0 and i == 0:
            self.walled = True
            temp = False
        if self.current_pos[0] == 0 and self.current_pos[1] == 1 and j == 0 and i == 2:
            self.walled = True
            temp = False
        if self.current_pos[0] == 1 and self.current_pos[1] == 1 and j == 1 and i == 0:
            self.walled = True
            temp = False
        if self.current_pos[0] == 2 and self.current_pos[1] == 1 and j == 2 and i == 0:
            self.walled = True
            temp = False
        if self.current_pos[0] == 0 and self.current_pos[1] == 2 and j == 0 and i == 1:
            self.walled = True
            temp = False
        if self.current_pos[0] == 1 and self.current_pos[1] == 0 and j == 1 and i == 1:
            self.walled = True
            temp = False
        if self.current_pos[0] == 2 and self.current_pos[1] == 0 and j == 2 and i == 1:
            self.walled = True
            temp = False

        return temp

    # This function coverts 2 kind of state location, for example: (11)->(2,1) or (1,0)->(5)
    def convert(self, pos, cond='to axis'):
        if cond == 'to axis':
            i = pos % 5
            j = int((pos - i) / 5)
            return (j, i)
        elif cond == 'to index':
            return pos[0] * 5 + pos[1]
        else:
            raise print("INVALID CONDITION !")

    # This function tells what is next state based on action we take.
    def move(self, action):
        if action == UP:
            return (self.current_pos[0] - 1, self.current_pos[1])
        elif action == LEFT:
            return (self.current_pos[0], self.current_pos[1] - 1)
        elif action == RIGHT:
            return (self.current_pos[0], self.current_pos[1] + 1)
        elif action == DOWN:
            return (self.current_pos[0] + 1, self.current_pos[1])
        else:
            raise print("WRONG ACTION WAS TAKEN!")

    # Based on next state , this will return rewards assigned to it.
    def return_reward(self):
        reward = 0
        j = self.further_pos[0]
        i = self.further_pos[1]
        if self.walled:
            reward -= 1
            self.walled = False
        if j == 0 and i == 0:
            reward += 10
        if j == 1 and i == 2:
            reward -= 10
        return reward

    # checks if next state is terminal state or not.
    def if_done(self):
        if self.further_pos == self.terminal_state:
            return True
        else:
            return False

    # After knowing next state, this checks boundaries and sets possible nest state.
    def next_state(self, action):
        temp_next_state = self.move(action)
        if self.check_boundaries(temp_next_state):
            self.further_pos = temp_next_state
        else:
            self.further_pos = self.current_pos

        if self.further_pos[0] == 0 and self.further_pos[1] == 1:
            self.damaged = False
        if self.further_pos[0] == 1 and self.further_pos[1] == 2:
            self.damaged = True

    # resets Env.
    def reset(self, exploring_start=True):
        self.further_pos = (0, 0)
        if exploring_start:
            self.current_pos = self.random_pos_selector()
            self.itter += 1
        else:
            self.current_pos = (0, 0)
        self.current_state = self.convert(self.current_pos, 'to index')

    # Based on windy world there will be an stochastic moving UP with possibility of 0.4 .
    def random_action(self, action):
        if action == 0:
            if np.random.uniform(0, 1, 1) < 0.4:
                return 2
        return action

    # in random_pos_selector section, we run this and explore based on random start position at each episode
    def random_pos_selector(self):
        j = np.random.randint(3)
        i = np.random.randint(4)
        if i == 0 and j == 0:
            return (3, 4)
        else:
            return (j, i)

    # based o which action was taken, return ( Next state , Reward , Done condition , More information)
    def step(self, action):
        action = self.random_action(action)
        self.next_state(action)
        done = self.if_done()
        info = "action " + str(action) + " was taken in state " + str(self.current_pos)
        reward = self.return_reward()
        state_prim = self.convert(self.further_pos, 'to index')
        self.current_pos = self.further_pos
        return state_prim, reward, done, info


#Normal Q learning function, nothing special for this question, you can change the map in Env it will work.
class Q_learning():
    def __init__(self, dscnt_fctr, n_episodes, epsilon, alpha, env, QInit, choose='e greedy'):
        self.epsilon = epsilon
        self.nS = env.nS
        self.nA = env.nA
        self.env = env
        self.Q = np.zeros((self.nS, self.nA))+QInit+0.001
        self.decaying = False
        self.alpha = alpha
        self.n_episodes = n_episodes
        self.reward_per_episode = []
        self.dscnt_fctr = dscnt_fctr
        self.policy = np.zeros((self.nS, self.nA))
        self.max_reward = 0
        self.action_state = []
        self.choose = choose

    def max_checker(self, cummulative_reward, s_a):
        if cummulative_reward > self.max_reward:
            self.max_reward = cummulative_reward
            self.policy = np.zeros((self.nS, self.nA))
            self.action_state = []
            self.action_state = s_a
            for i in range(self.nS):
                self.policy = np.argmax(self.Q[i, :])

    def decay(self):
        self.alpha -= 1 / (self.n_episodes + 1)
        self.epsilon = (self.epsilon / (self.n_episodes + 1)) * (self.n_episodes - 10)

    def e_greedy_choose(self, state):
        temp = self.Q[state, :]
        best = np.argmax(temp)
        probs = (np.ones(self.nA) / self.nA) * self.epsilon
        probs[best] += 1 - self.epsilon
        return np.random.choice(self.nA, 1, p=probs)[0]

    def run(self):
        for eps in range(self.n_episodes):
            self.env.reset(exploring_start=True)
            done = False
            state = self.env.current_state
            reward_sum = 0
            i = 0
            a_s = []
            while not done:
                if self.choose == 'e greedy':
                    action = self.e_greedy_choose(state)
                state_prim, reward, done, info = self.env.step(action)
                a_s.append((state, action))
                try:
                    reward_sum += reward
                except:
                    print(reward)
                self.Q[state, action] += self.alpha * (reward + self.dscnt_fctr * self.Q[state_prim, np.argmax(self.Q[state_prim, :])] - self.Q[state, action])
                state = state_prim
                i += 1
                if done:
                    if eps > 100:
                        self.max_checker(reward_sum, a_s)
                    self.reward_per_episode.append(reward_sum)
                    break
            if self.decaying:
                self.decay()
        q=1


map = np.array([[3, 2, 0, 0, 0], [0, 0, 1, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0]])
env = Maze_ENV(map)
dq = Q_learning(0.5, 1000, 0.2, 0.1, env, 0)            #testcase 1
dq.run()

fig = plt.figure(figsize=(15,6))
fig.patch.set_facecolor('yellow')
fig.patch.set_alpha(0.47)
ax = fig.add_subplot(111)
ax.plot(dq.reward_per_episode , color='white',linewidth=0.6)
ax.patch.set_facecolor('red')
ax.patch.set_alpha(0.2)
plt.title('Q-Learning rewards per episode plot1')
plt.xlabel('Episode')
plt.ylabel('Reward')
plt.legend(['Q-Learning - 0 Reward for cell "4" ' ], loc='lower right')
plt.show()



dq = Q_learning(0.5, 1000, 0.2, 0.1, env, 20)            #testcase 2
dq.run()

fig = plt.figure(figsize=(15,6))
fig.patch.set_facecolor('yellow')
fig.patch.set_alpha(0.47)
ax = fig.add_subplot(111)
ax.plot(dq.reward_per_episode , color='white',linewidth=0.6)
ax.patch.set_facecolor('red')
ax.patch.set_alpha(0.2)
plt.title('Q-Learning rewards per episode plot2')
plt.xlabel('Episode')
plt.ylabel('Reward')
plt.legend(['Q-Learning - 0 Reward for cell "4" ' ], loc='lower right')
plt.show()



dq = Q_learning(0.5, 1000, 0+0.05, 0.1, env, 0)            #testcase 3
dq.run()

fig = plt.figure(figsize=(15,6))
fig.patch.set_facecolor('yellow')
fig.patch.set_alpha(0.47)
ax = fig.add_subplot(111)
ax.plot(dq.reward_per_episode , color='white',linewidth=0.6)
ax.patch.set_facecolor('red')
ax.patch.set_alpha(0.2)
plt.title('Q-Learning rewards per episode plot3')
plt.xlabel('Episode')
plt.ylabel('Reward')
plt.legend(['Q-Learning - 0 Reward for cell "4" ' ], loc='lower right')
plt.show()



dq = Q_learning(0.1+0.3, 1000, 0.2, 0.1, env, 0)            #testcase 4
dq.run()

fig = plt.figure(figsize=(15,6))
fig.patch.set_facecolor('yellow')
fig.patch.set_alpha(0.47)
ax = fig.add_subplot(111)
ax.plot(dq.reward_per_episode , color='white',linewidth=0.6)
ax.patch.set_facecolor('red')
ax.patch.set_alpha(0.2)
plt.title('Q-Learning rewards per episode plot4')
plt.xlabel('Episode')
plt.ylabel('Reward')
plt.legend(['Q-Learning - 0 Reward for cell "4" ' ], loc='lower right')
plt.show()



dq = Q_learning(0.5, 1000, 0.2, 0.9, env, 0)            #testcase 5
dq.run()

fig = plt.figure(figsize=(15,6))
fig.patch.set_facecolor('yellow')
fig.patch.set_alpha(0.47)
ax = fig.add_subplot(111)
ax.plot(dq.reward_per_episode , color='white',linewidth=0.6)
ax.patch.set_facecolor('red')
ax.patch.set_alpha(0.2)
plt.title('Q-Learning rewards per episode plot5')
plt.xlabel('Episode')
plt.ylabel('Reward')
plt.legend(['Q-Learning - 0 Reward for cell "4" ' ], loc='lower right')
plt.show()
