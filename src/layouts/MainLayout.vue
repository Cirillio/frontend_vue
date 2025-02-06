<script setup>
import MainHeader from "../components/MainHeader.vue";
import MainDrawer from "../components/MainDrawer.vue";
</script>

<template>
  <MainDrawer />
  <MainHeader />
  <main>
    <RouterView />
  </main>
</template>

<style scoped></style>
