<script setup>
import { ref } from "vue";
const isFocused = ref(false);
</script>

<template>
  <div class="text-text work-sans flex flex-col gap-5 w-full">
    <h2 class="h2 font-semibold">Browse Marketplace</h2>
    <p class="p font-light">Browse through more than 50k NFTs on the NFT Marketplace.</p>
    <div
      :class="[isFocused ? 'border-zinc-300' : 'border-zinc-700']"
      class="w-full flex h-fit items-center justify-between transition-all group border rounded-[20px] overflow-hidden"
    >
      <input
        @focus="isFocused = true"
        @blur="isFocused = false"
        placeholder="Search your favorite NFTs"
        type="text"
        class="work-sans w-full px-3 focus:outline-0"
      />
      <div
        class="max-h-12 flex items-center justify-center transition-all hover:bg-backgroundSecond px-3 py-6 cursor-pointer"
      >
        <img class="select-none" src="/public/icons/Search.svg" alt="browse" />
      </div>
    </div>
  </div>
</template>
