import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import StoreList from './views/dictionary/stores/StoreList'

Vue.config.productionTip = false
Vue.use(VueRouter)

const routes = [
  { path: '/Stores', component: StoreList }
]
const router = new VueRouter({
  routes // short for `routes: routes`
})

new Vue({
  render: h => h(App),
  router,
}).$mount('#app')
