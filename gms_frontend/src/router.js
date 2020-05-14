import Vue from 'vue'
import Router from 'vue-router'
// import Home from './components/HelloWorld.vue'


Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [{
    path: '/',
    name: 'home',
    component: () => import('./views/GradeManage.vue')
  },
  {
    path: '/grademanage',
    name: 'GradeManage',
    component: () => import('./views/GradeManage.vue')
  },
  {
    path: '/accountmanage',
    name: 'AccountManage',
    component: () => import('./views/AccountManage.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('./views/Login.vue')
  },
  {
    path: '/grademanage/searchgrade',
    name: 'searchHistoryByTeacher',
    component: () => import('./components/searchHistoryByTeacher.vue')
  },
  {
    path: '/grademanage/searchgrade/result',
    name: 'result',
    component: () => import('./components/result.vue')
  },
  ]
})
