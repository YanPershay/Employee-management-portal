<template>
  <div id="v-main-wrapper">
    <Header />
    <NavBar />
    <router-view></router-view>
  </div>
</template>

<script>
import Header from "./Header.vue";
import NavBar from "./NavBar.vue";

export default {
  name: "App",
  components: {
    Header, NavBar
  },
  methods: {},
};
</script>

<style>
 .v-main-wrapper {
     margin: 0 auto;
 }
</style>