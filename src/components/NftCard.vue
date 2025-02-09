<script setup>
defineProps({
  img: String,
  name: String,
  artist: Object,
  price: {
    type: Number,
    default: 0,
  },
  highBid: {
    type: Number,
    default: 0,
  },
});
</script>
<template>
  <div class="overflow-hidden rounded-[20px]">
    <img class="aspect-square w-full" :src="img" :alt="name" />
    <div class="px-8 pb-7 pt-5 bg-background w-full flex flex-col gap-6">
      <div class="flex flex-col gap-1">
        <h5 class="h5 work-sans text-text font-semibold">{{ name }}</h5>
        <div class="b space-mono text-text gap-2 flex items-center font-light">
          <img class="aspect-square max-h-6" :src="artist.avatar" :alt="artist.name" />
          <p>{{ artist.name }}</p>
        </div>
      </div>

      <div class="flex flex-col gap-1">
        <div class="c space-mono text-neutral-500 flex justify-between">
          <p>Price</p>
          <p>Highest Bid</p>
        </div>
        <div class="b space-mono text-text font-[400] flex justify-between">
          <p>{{ price }} ETH</p>
          <p>{{ highBid }} wETH</p>
        </div>
      </div>
    </div>
  </div>
</template>
