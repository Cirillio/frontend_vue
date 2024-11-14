<script setup>
import Header from './components/Header.vue'
import CardList from './components/CardList.vue'
import Drawer from './components/Drawer.vue'
</script>

<template>
  <Drawer />
  <div class="w-4/5 m-auto bg-white h-full rounded-xl shadow-xl mt-10">
    <Header />

    <div class="p-10">
      <h2 class="text-3xl font-bold mb-5">Все кроссовки</h2>
      <CardList />
    </div>
  </div>
</template>

<style></style>
