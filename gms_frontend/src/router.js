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
        path: '/accountmanage/createAccount',
        name: 'createAccount',
        component: () => import('./components/accountManage/Register.vue')
    },
    {
        path: '/accountmanage/searchAccount',
        name: 'searchAccount',
        component: () => import('./components/accountManage/searchAccount.vue')
    },
    {
        path: '/accountmanage/createAccount/result',
        name: 'resultOfCreateAccount',
        component: () => import('./components/accountManage/result.vue')
    },
    {
        path: '/grademanage/student/',
        name: 'studentSearchgradeMainPage',
        component: () => import('./components/studentSearchGrade/student.vue')
    },
    {
        path: '/grademanage/student/searchgrade',
        name: 'studentSearchgrade',
        component: () => import('./components/studentSearchGrade/searchGrade.vue')
    },
    {
        path: '/grademanage/acadamicAffair/',
        name: 'acadamicAffairSearchGradeMainPage',
        component: () => import('./components/AcadamicAffairSearchGrade/AcadamicAffair.vue')
    },
    {
        path: '/grademanage/acadamicAffair/searchgrade/course/result',
        name: 'acadamicAffairSearchGradeByCourseId',
        component: () => import('./components/AcadamicAffairSearchGrade/searchGradeByCourseId.vue')
    },
    {
        path: '/grademanage/acadamicAffair/searchgrade/student/result',
        name: 'acadamicAffairSearchGradeByStudentId',
        component: () => import('./components/AcadamicAffairSearchGrade/searchGradeByStudentId.vue')
    },
    ]
})
