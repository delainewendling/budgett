import Vue from 'vue';
import HelloWorld from './components/HelloWorld.vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter)

const routes = [
  { path: '/home', component: HelloWorld},
  { path: '*', redirect: '/home' }
]

export const router = new VueRouter({
  routes
});

const app = new Vue({
  el: '#app',
  router: router,
  render: h => h(HelloWorld)
});