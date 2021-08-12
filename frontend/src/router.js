import Vue from 'vue'
import Router from 'vue-router'
import Employee from './components/Employee.vue'
import Department from './components/Department.vue'
import Home from './components/Home.vue'

Vue.use(Router)

let router = new Router({
    routes: [
        {
            path: "/employee",
            name: 'Employee',
            component: Employee

        },
        {
            path: "/department",
            name: 'Department',
            component: Department

        },
        {
            path: "/home",
            name: 'Home',
            component: Home

        }
    ]
})

export default router