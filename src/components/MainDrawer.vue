<script setup>
import { useDrawerStore } from "../stores/drawerStore";
const drawerStore = useDrawerStore();
</script>

<template>
  <Transition name="fade">
    <div
      v-if="drawerStore.drawer"
      @click="drawerStore.close"
      class="fixed w-full h-full bg-[rgba(0,0,0,0.5)] z-10 flex"
    ></div>
  </Transition>

  <Transition name="slide">
    <aside
      v-if="drawerStore.drawer"
      class="fixed top-0 right-0 h-full w-2/3 md:w-64 z-20 text-text work-sans font-semibold bg-backgroundSecond flex flex-col gap-2"
    >
      <div class="flex items-center m-5 justify-evenly">
        <button class="btn b py-4 px-6 max-w-fit overflow-hidden">
          <img src="/public/icons/User.svg" alt="user" />
          <p>Sign Up</p></button
        ><img
          @click="drawerStore.close"
          class="burger invert"
          src="/public/icons/Close.svg"
          alt="burgerMenu"
        />
      </div>
      <ul
        class="flex flex-col w-full text-center md:text-start b [&>*]:hover:underline [&>*]:focus:bg-zinc-500 [&>*]:hover:bg-zinc-500 [&>*]:py-5 [&>*]:transition-all"
      >
        <router-link @click="drawerStore.close" :to="{ name: 'Marketplace' }">
          <li class="px-5 cursor-pointer">Marketplace</li>
        </router-link>
        <router-link @click="drawerStore.close" :to="{ name: 'dev' }">
          <li class="px-5 cursor-pointer">Rankings</li>
        </router-link>
        <router-link @click="drawerStore.close" :to="{ name: 'dev' }">
          <li class="px-5 cursor-pointer">Connect a wallet</li>
        </router-link>
      </ul>
    </aside>
  </Transition>
</template>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}

/* Анимация бокового сайдбара */
.slide-enter-active,
.slide-leave-active {
  transition: transform 0.5s ease, opacity 0.5s ease;
}

.slide-enter-from,
.slide-leave-to {
  transform: translateX(100%); /* Сайдбар начинает движение справа за экраном */
}

.slide-enter-to,
.slide-leave-from {
  transform: translateX(0); /* Сайдбар находится в правой части экрана */
}
</style>
