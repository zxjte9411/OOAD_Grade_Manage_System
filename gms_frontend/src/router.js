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
    name: 'resultOfSearchgrade',
    component: () => import('./components/result.vue')
  },
  {
    path: '/grademanage/course',
    name: 'SelectCourse',
    component: () => import('./components/SelectCourse.vue')
  },
  {
    path: '/grademanage/course/logingrade',
    name: 'LoginGrade',
    component: () => import('./components/LoginStudentGrade.vue')
  },
  {
    path: '/accountmanage/selectdepartment',
    name: 'selectdepartment',
    component: () => import('./components/accountManage/SelectDepartment.vue')
  },
  {
    path: '/accountmanage/createAccount/result',
    name: 'resultOfCreateAccount',
    component: () => import('./components/accountManage/result.vue')
  },
  {
    path: '/accountmanage/createAccount',
    name: 'createAccount',
    component: () => import('./components/accountManage/Register.vue')
  },
  
  {
    path: '/test',
    name: 'test',
    component: () => import('./views/IssuePage.vue')
  },
  ]
})
