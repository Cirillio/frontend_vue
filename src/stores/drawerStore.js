import { defineStore } from "pinia";

export const useDrawerStore = defineStore("drawer", {
  state: () => ({
    drawer: false,
  }),
  actions: {
    open() {
      this.drawer = true;
    },
    close() {
      this.drawer = false;
    },
  },
});
