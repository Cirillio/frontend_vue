<script setup>
import MP_NftList from "../components/MP_NftList.vue";
import { ref } from "vue";
const isFocused = ref(false);

const switchPage = ref(true);
</script>

<template>
  <div v-auto-animate>
    <div class="global-px py-10 xl:py-20 text-text work-sans flex flex-col gap-5 w-full">
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
    <div
      class="w-full global-px flex border-0 border-t-[1px] border-t-zinc-400 work-sans [&>*]:cursor-pointer"
    >
      <button
        @click="switchPage = true"
        :class="[switchPage ? 'active-btn-mp' : 'inactive-btn-mp ']"
        class="flex border-b-[2px] w-full flex-1 gap-3 justify-center items-center py-2 transition-all duration-75"
      >
        <h5 class="h5 font-semibold">NFTs</h5>
        <p class="space-mono text-text rounded-[20px] px-2 py-0.5 font-ultralight">302</p>
      </button>
      <button
        @click="switchPage = false"
        :class="[switchPage === false ? 'active-btn-mp' : 'inactive-btn-mp ']"
        class="flex border-b-[2px] flex-1 gap-3 justify-center items-center py-2 transition-all duration-75"
      >
        <h5 class="h5 font-semibold">Collections</h5>
        <p class="space-mono text-text b rounded-[20px] px-2 py-0.5 font-ultralight">67</p>
      </button>
    </div>
    <MP_NftList v-if="switchPage" />
  </div>
</template>

<style scoped>
.active-btn-mp {
  border-bottom-color: var(--color-zinc-300);
}

.active-btn-mp h5 {
  color: var(--color-text);
}

.active-btn-mp p {
  background-color: gray;
}

.inactive-btn-mp {
  border-bottom-color: var(--color-background);
}
.inactive-btn-mp h5 {
  color: gray;
}

.inactive-btn-mp p {
  background-color: var(--color-backgroundSecond);
}
</style>
