<template>
  <form @submit.prevent="submit">
    <h1 class="h3 mb-3 fw-normal">Please sign in</h1>
    <input v-model="email" type="email" placeholder="Email" required>
    <input  v-model="password" type="password" placeholder="Password" required>

    <button type="submit">Sign in</button>
  </form>
</template>

<style scoped>
form{
    min-width: 150px;
    max-width: 500px;
    width: 100%;
}

button{
 
}
</style>

<script>
export default ({
  name: "Login",
  data(){
    return {
      email: '',
      password: ''
    }
  },
  methods:{
    async submit(){
      const data = {
      email : this.email,
      password : this.password
      };
      console.log( JSON.stringify(data));

      await fetch('Account/Login', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        credentials: 'include',
        body: JSON.stringify(data)
      });

    }
  }

})
</script>



