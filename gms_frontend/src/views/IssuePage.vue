<template>
    <div>
        <NavBar />

        <b-container fluid class="pl-5 pr-5 mt-3">
            <b-card class="mb-3" title="建立帳號">
                <b-form>
                    <b-form-group id="input-group-userInformation">
                        <b-row class="pb-3">
                            <b-col>
                                <label for="input-name">姓名</label>
                                <b-form-input v-model="userInformation.name" id="input-name" required></b-form-input>
                            </b-col>
                            <b-col>
                                <label for="input-gender">性別</label>
                                <b-form-select v-model="userInformation.gender" id="input-gender" :options="genderOptions" required></b-form-select>
                            </b-col>
                        </b-row>
                        <b-row class="pb-3">
                            <b-col>
                                <label for="input-birthday">生日</label>
                                <b-form-input v-model="userInformation.birthday" id="input-birthday" type="datetime-local" required></b-form-input>
                            </b-col>
                            <b-col>
                                <label for="input-phone">電話</label>
                                <b-form-input v-model="userInformation.phone" id="input-phone" type="number" required></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row class="pb-3">
                            <b-col cols="4" offset="2">
                                <label for="input-authority">身份</label>
                                <b-form-select id="input-authority" v-model="userInformation.authority" :options="authorityOptions"></b-form-select>
                            </b-col>

                        </b-row>
                        <b-row class="pb-3">
                            <b-col>
                                <label for="input-address">地址</label>
                                <b-form-input v-model="userInformation.address" id="input-address" required></b-form-input>
                            </b-col>
                        </b-row>
                    </b-form-group>
                </b-form>
            </b-card>
        </b-container>
        <b-button variant="secondary" @click="submit">修改</b-button>
    </div>
</template>

<script>
    import _ from 'lodash';
    import NavBar from '@/components/NavBar.vue';

    export default {
        name: 'IssuePage',
        components: {
            NavBar
        },
        data() {
            return {
                authority: '',
                userInformation: {
                    name: '',
                    gender: '',
                    phone: '',
                    birthday: '',
                    address: '',
                },
                genderOptions:[
                    { value: '男', text: '男' },
                    { value: '女', text: '女' },
                ],
                authorityOptions:[
                    { value: 0, text: '管理員' },
                    { value: 1, text: '教職員' },
                    { value: 2, text: '教　師' },
                    { value: 3, text: '學　生' }
                ],
            };
        },
        methods: {
            submit(){
                const vm = this;
                console.log(this.userInformation)
                const api = `${process.env.VUE_APP_APIPATH}api/admin/accounts/department/` + vm.$route.departmentID;
                const token = localStorage.getItem('token');
                this.$http.get(
                    api,
                    { headers: { Authorization: `Bearer ${token}`, "content-type": "application/json;charset=utf-8"}}
                ).
                then((response) => {
                    console.log(response)
                    if(response.status == 200){
                        vm.issue = response.data;
                    }
                });      
            },
            getIssue() {
                const vm = this;
                const api = `${process.env.VUE_APP_APIPATH}/api/issue/` + vm.$route.params.id;
                const token = localStorage.getItem('token');
                this.$http.get(
                    api,
                    { headers: { "Authorization": "Bearer " + token, "content-type": "application/json;charset=utf-8"}}
                ).
                then((response) => {
                    console.log(response)
                    if(response.status == 200){
                        vm.issue = response.data;
                    }
                }); 
            },
            getAllProject(){
                const api = `${process.env.VUE_APP_APIPATH}/api/project`;
                const vm = this;
                const token = localStorage.getItem('token');
                this.$http.get(
                    api,
                    { headers: { "Authorization": "Bearer " + token, "content-type": "application/json;charset=utf-8"}}
                ).
                then((response) => {
                    // console.log(response)
                    if(response.status == 200){
                        response.data.forEach(project => vm.projectOptions.push({ id: project.id, name: project.name }));
                    }
                }); 
            },
            getAllUser(){
                const api = `${process.env.VUE_APP_APIPATH}/api/user`;
                const vm = this;
                const token = localStorage.getItem('token');
                this.$http.get(
                    api,
                    { headers: { "Authorization": "Bearer " + token, "content-type": "application/json;charset=utf-8"}}
                ).
                then((response) => {
                    // console.log(response)
                    if(response.status == 200){
                        response.data.forEach(user => vm.users.push({ value: user.id, text: user.name }));
                    }
                }); 
            },
            updateIssue(){
                const vm = this;
                const api = `${process.env.VUE_APP_APIPATH}/api/issue/` + vm.issue.id;
                const token = localStorage.getItem('token');
                this.$http.post(
                    api,
                    vm.issue,
                    { headers: { "Authorization": "Bearer " + token, "content-type": "application/json;charset=utf-8"}}
                ).
                then((response) => {
                    if(response.status == 200){
                        alert('修改成功');
                        vm.$route.go()
                    }
                }); 

            }
        },
        created() {}
    }
</script>