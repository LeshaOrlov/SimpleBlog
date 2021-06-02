<template>
  <div class="hello">
    <div v-if="role == 'admin'">
      <h1>Hello Admin!</h1>
      <img alt="Vue logo" src="../assets/logo.png" />
    </div>
    <div class="post" v-for="post in posts" :key="post.id">
      <v-card class="mx-auto my-12" elevation="5">
        <v-card-title>{{ post.title }}</v-card-title>
        <v-divider class="mx-4"></v-divider>
      <v-card-text class="content">{{ post.body }}</v-card-text>
      </v-card>
    </div>
  </div>
</template>

<script>
export default {
  name: "Posts",
  data() {
    return {
      posts: [],
    };
  },
  mounted: function () {
    fetch("https://jsonplaceholder.typicode.com/posts")
      .then((res) => res.json())
      .then((x) => (this.posts = x));
  },

  computed: {
    role() {
      return this.$store.getters.getRole;
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.hello{
  margin: 0 auto;
  max-width: 1040px;
  width: 100%;
}

.content{
  padding: 70px 150px 0;
}
</style>
