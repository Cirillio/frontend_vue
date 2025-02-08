<script setup>
import { useDrawerStore } from "../stores/drawerStore";
const drawerStore = useDrawerStore();
</script>
<template>
  <header
    class="flex w-full h-24 items-center justify-between px-6 md:px-12 py-5 text-text work-sans font-semibold"
  >
    <router-link :to="{ name: 'MainPage' }">
      <div class="flex gap-4 items-center cursor-pointer">
        <img src="/public/icons/Storefront.svg" alt="logo" />
        <span class="space-mono text-xl text-nowrap">NFT Marketplace</span>
      </div>
    </router-link>
    <div class="gap-2.5 items-center min-[100px]:hidden xl:flex">
      <ul
        class="flex gap-2.5 b [&>*>*]:text-text [&>*>*]:hover:text-lime-500 [&>*>*]:transition-all duration-1000"
      >
        <router-link :to="{ name: 'Marketplace' }">
          <li class="py-3 px-5 cursor-pointer">Marketplace</li>
        </router-link>
        <router-link :to="{ name: 'MainPage' }">
          <li class="py-3 px-5 cursor-pointer">Rankings</li>
        </router-link>
        <router-link :to="{ name: 'MainPage' }">
          <li class="py-3 px-5 cursor-pointer">Connect a wallet</li>
        </router-link>
      </ul>
      <button class="btn b py-4 px-6">
        <img src="/public/icons/User.svg" alt="user" />
        <p>Sign Up</p>
      </button>
    </div>
    <img
      @click="drawerStore.open"
      class="burger"
      src="/public/icons/Burger Menu.svg"
      alt="burgerMenu"
    />
  </header>
</template>
