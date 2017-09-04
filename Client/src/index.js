import Vue from 'vue';
import App from './components/App.vue';
import Insights from './components/Insights.vue';
import Transactions from './components/Transactions.vue';
import Settings from './components/Settings.vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter)

const routes = [
  { path: '/insights', component: Insights},
  { path: '/transactions', component: Transactions},
  { path: '/settings', component: Settings},
  { path: '*', redirect: '/insights' }
]

export const router = new VueRouter({
  routes
});

const app = new Vue({
  el: '#app',
  router: router,
  render: h => h(App)
});