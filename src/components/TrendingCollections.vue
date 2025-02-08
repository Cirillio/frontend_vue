<script setup>
import { onMounted, ref } from "vue";
import HighlightedCollection from "./HighlightedCollection.vue";
import { useHighlightedCollectionsStore } from "../stores/highlightedCollections";

const highlightedCollections = useHighlightedCollectionsStore();

onMounted(async () => {
  await highlightedCollections.fetchHighlighted();
});
</script>
<template>
  <div v-if="highlightedCollections.isLoading" class="p mx-auto text-text space-mono">
    loading...
  </div>
  <div
    v-if="highlightedCollections.highlighted_collections.length > 1"
    class="flex flex-col w-full text-text work-sans"
  >
    <h3 class="h3 font-semibold">Trending Collections</h3>
    <p class="p">Checkout our weekly updated trending collection.</p>
    <div class="mt-5 flex flex-col md:flex-row gap-5 w-full">
      <HighlightedCollection
        v-for="collection in highlightedCollections.highlighted_collections"
        :key="collection.id"
        :id="collection.id"
        :name="collection.name"
        :avatar="collection.artist.avatar"
        :artist="collection.artist.name"
        :nfts="collection.nfts"
        :remaining="collection.remaining"
      />
    </div>
  </div>
</template>
