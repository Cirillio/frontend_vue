<script setup>
import { inject } from 'vue'
import CardList from '@/components/CardList.vue'

const { favorites } = inject('favorites')
</script>

<template>
  <h2>Мои закладки</h2>
  <CardList :products="favorites" />
</template>
