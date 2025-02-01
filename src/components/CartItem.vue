<script setup>
import { inject, ref } from 'vue'
const props = defineProps({
  id: Number,
  name: String,
  price: Number,
  imgUrl: String,
  OnClickCart: Function,
})

const checkPos = ref(props.id > 1)
</script>

<template>
  <div v-if="checkPos" class="w-full h-[1px] bg-gray-300 rounded-lg"></div>
  <div
    class="relative flex max-h-28 gap-5 cursor-pointer px-3 py-5 rounded-xl transition-all group duration-200"
  >
    <img class="w-20 h-20" :src="imgUrl" :alt="id + '. ' + name" />
    <div class="flex flex-col flex-1">
      <p>{{ name }}</p>
      <div class="flex items-center justify-between">
        <b>{{ price }}р.</b>
        <img
          class="cursor-pointer opacity-40 hover:opacity-100 transition-all"
          src="/public/close.svg"
          alt="remove"
          @click="OnClickCart"
        />
      </div>
    </div>
    <div
      class="absolute opacity-0 group-hover:opacity-100 transition-all duration-500 bg-green-500 h-[50%] w-[2px] rounded-lg top-[50%] translate-y-[-50%] right-0"
    ></div>
    <div
      class="absolute opacity-0 group-hover:opacity-100 transition-all duration-500 bg-green-500 h-[50%] w-[2px] rounded-lg top-[50%] translate-y-[-50%] left-0"
    ></div>
  </div>
</template>

<style></style>
