import { defineStore } from "pinia";

export const useDrawerStore = defineStore("drawer", {
  state: () => ({
    drawer: false,
  }),
  actions: {
    switch() {
      this.drawer = !this.drawer;
    },
  },
});
