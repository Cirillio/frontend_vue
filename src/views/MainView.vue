<script setup>
import MainHighlighted from "../components/MainHighlighted.vue";
import TrendingCollections from "../components/TrendingCollections.vue";
</script>

<template>
  <div v-auto-animate class="w-full flex flex-col global-px py-10 xl:py-20 items-center gap-36">
    <MainHighlighted /> <TrendingCollections />
  </div>
</template>
