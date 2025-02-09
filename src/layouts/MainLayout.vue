<script setup>
import MainHeader from "../components/MainHeader.vue";
import MainFooter from "../components/MainFooter.vue";
import MainDrawer from "../components/MainDrawer.vue";
</script>

<template>
  <MainDrawer />
  <div class="min-h-dvh flex flex-col">
    <MainHeader />
    <main v-auto-animate>
      <RouterView />
    </main>
    <MainFooter />
  </div>
</template>

<style scoped></style>
