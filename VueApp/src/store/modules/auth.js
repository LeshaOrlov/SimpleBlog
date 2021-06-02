export default {
    state: {
      user: {},
      role: 'admin',
      authenticated: false
    },
    mutations: {
      SET_AUTH: (state, auth) => state.authenticated = auth
    },
    actions: {
      setAuth(context, auth) { context.commit('SET_AUTH', auth) }
    },
    getters: {
        getRole(state){
            return state.role
        }
    }
  };