<script setup>
import NftCard from "./NftCard.vue";
</script>

<template>
  <div
    v-auto-animate
    class="global-px py-20 bg-backgroundSecond grid gap-7 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3"
  >
    <NftCard
      :key="1"
      :img="'/nfts/nft_1.png'"
      :name="'doggy'"
      :artist="{ name: 'gooler', avatar: '/avatars/avatar_1.png' }"
      :price="10000"
    />
    <NftCard
      :key="1"
      :img="'/nfts/nft_1.png'"
      :name="'doggy'"
      :artist="{ name: 'gooler', avatar: '/avatars/avatar_1.png' }"
      :price="10000"
    />
    <NftCard
      :key="1"
      :img="'/nfts/nft_1.png'"
      :name="'doggy'"
      :artist="{ name: 'gooler', avatar: '/avatars/avatar_1.png' }"
      :price="10000"
    />
    <NftCard
      :key="1"
      :img="'/nfts/nft_1.png'"
      :name="'doggy'"
      :artist="{ name: 'gooler', avatar: '/avatars/avatar_1.png' }"
      :price="10000"
    />
  </div>
</template>
