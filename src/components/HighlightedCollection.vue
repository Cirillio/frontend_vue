<script setup>
defineProps({
  id: Number,
  name: String,
  avatar: String,
  artist: String,
  nfts: Array,
  remaining: Number,
});
</script>
<template>
  <router-link :to="{ name: 'dev' }">
    <div class="flex flex-col gap-3 group">
      <img
        class="flex w-full aspect-square rounded-[20px] cursor-pointer"
        :src="'../..' + nfts[0].img"
        alt="nft_1"
      />
      <div
        class="w-full grid grid-cols-3 grid-rows-1 gap-x-3 [&>*]:cursor-pointer [&>*]:rounded-[20px] [&>*]:aspect-square"
      >
        <img :src="'../..' + nfts[1].img" alt="nft_2" />
        <img :src="'../..' + nfts[2].img" alt="nft_3" />
        <h5 class="flex bg-action space-mono items-center justify-center h5">{{ remaining }}+</h5>
      </div>
      <h5
        class="h5 w-fit cursor-pointer work-sans font-semibold transition-all group-hover:translate-x-5 group-hover:underline"
      >
        {{ name }}
      </h5>
      <div class="flex gap-2 items-center h-fit">
        <img
          class="rounded-full max-h-6 aspect-square cursor-pointer"
          :src="'../..' + avatar"
          alt="artist"
        />
        <p class="b flex-1 work-sans cursor-pointer">{{ artist }}</p>
      </div>
    </div>
  </router-link>
</template>
