<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { inject } from 'vue'
defineProps({ totalPrice: Number })
const { openDrawer } = inject('cart')
</script>

<template>
  <header
    class="flex justify-between flex-wrap border-b border-slate-200 px-8 py-5 flex-col gap-5 items-center md:flex-row md:gap-0 md:justify-between"
  >
    <router-link to="/">
      <div class="flex items-center gap-5">
        <img src="/logo.png" alt="Logo" class="w-10" />
        <div>
          <h1 class="text-xl font-bold uppercase">Vue Sneakers</h1>
          <p class="text-slate-400">Лучшие кроссовки!</p>
        </div>
      </div></router-link
    >

    <ul class="flex items-center gap-5">
      <li
        v-on:click="openDrawer"
        class="flex items-center cursor-pointer gap-2 text-gray-400 hover:text-black"
      >
        <img src="/cart.svg" alt="cart" />
        <b>{{ totalPrice }}р.</b>
      </li>
      <router-link to="/favorites">
        <li class="flex items-center cursor-pointer gap-2 text-gray-400 hover:text-black">
          <img src="/heart.svg" alt="heart" />
          <span>Закладки</span>
        </li>
      </router-link>
      <li class="flex items-center cursor-pointer gap-2 text-gray-400 hover:text-black">
        <img src="/profile.svg" alt="profile" />
        <span>Профиль</span>
      </li>
    </ul>
  </header>
</template>

<style></style>
