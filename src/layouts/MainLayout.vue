<script setup>
import MainHeader from "../components/MainHeader.vue";
import MainFooter from "../components/MainFooter.vue";
import MainDrawer from "../components/MainDrawer.vue";
</script>

<template>
  <MainDrawer />
  <div class="min-h-dvh flex flex-col">
    <MainHeader />
    <main class="w-full px-14 py-10 xl:px-40 2xl:px-60 xl:py-20 flex flex-col items-center gap-36">
      <RouterView />
    </main>
    <MainFooter />
  </div>
</template>

<style scoped></style>
