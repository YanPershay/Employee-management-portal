<template>
  <div class="v-nav-bar">
    <nav class="navbar navbar-expand-sm bg-light navbar-dark">
      <ul class="navbar-nav">
        <li class="nav-item m-1">
          <router-link class="btn btn-light btn-outline-primary" to="/home"
            >Home</router-link
          >
        </li>
        <li class="nav-item m-1">
          <router-link
            class="btn btn-light btn-outline-primary"
            to="/department"
            >Department</router-link
          >
        </li>
        <li class="nav-item m-1">
          <router-link
           class="btn btn-light btn-outline-primary"
           to="/employee"
            >Employee</router-link
          >
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
export default {
  name: "NavBar",
};
</script>

<style lang="scss">
    .v-nav-bar {
        margin-top: 20px;
        padding-top: 40px;
    }

@import "~bootstrap/dist/css/bootstrap.css";
</style>