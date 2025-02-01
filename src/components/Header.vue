<script setup>
const props = defineProps({ totalPrice: Number })
const emit = defineEmits(['openDrawer'])
</script>

<template>
  <header
    class="flex justify-between flex-wrap border-b border-slate-200 px-8 py-5 flex-col gap-5 items-center md:flex-row md:gap-0 md:justify-between"
  >
    <div class="flex items-center gap-5">
      <img src="/logo.png" alt="Logo" class="w-10" />
      <div>
        <h1 class="text-xl font-bold uppercase">Vue Sneakers</h1>
        <p class="text-slate-400">Лучшие кросовки!</p>
      </div>
    </div>

    <ul class="flex items-center gap-5">
      <li
        @click="() => emit('openDrawer')"
        class="flex items-center cursor-pointer gap-2 text-gray-400 hover:text-black"
      >
        <img src="/cart.svg" alt="cart" />
        <b>{{ totalPrice }}р.</b>
      </li>
      <li class="flex items-center cursor-pointer gap-2 text-gray-400 hover:text-black">
        <img src="/heart.svg" alt="heart" />
        <span>Закладки</span>
      </li>
      <li class="flex items-center cursor-pointer gap-2 text-gray-400 hover:text-black">
        <img src="/profile.svg" alt="profile" />
        <span>Профиль</span>
      </li>
    </ul>
  </header>
</template>

<style></style>
