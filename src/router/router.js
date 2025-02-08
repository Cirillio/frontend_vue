import { createWebHistory, createRouter } from "vue-router";
import MainLayout from "../layouts/MainLayout.vue";
import MainView from "../views/MainView.vue";
import MarketplaceView from "../views/MarketplaceView.vue";
import SpaceInWork from "../views/SpaceInWork.vue";
const routes = [
  {
    path: "/",
    name: "Main",
    component: MainLayout,
    children: [
      {
        path: "/",
        name: "MainPage",
        component: MainView,
      },
      {
        path: "/marketplace",
        name: "Marketplace",
        component: MarketplaceView,
      },
      {
        path: "/dev",
        name: "dev",
        component: SpaceInWork,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
