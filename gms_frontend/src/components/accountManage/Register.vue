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
                                <b-form-input v-model="account.userInformation.name" id="input-name" required trim></b-form-input>
                            </b-col>
                            <b-col>
                                <label for="input-gender">性別</label>
                                <b-form-select v-model="account.userInformation.gender" id="input-gender" :options="genderOptions" required></b-form-select>
                            </b-col>
                        </b-row>
                        <b-row class="pb-3">
                            <b-col>
                                <label for="input-birthday">生日</label>
                                <b-form-input v-model="account.userInformation.birthday" id="input-birthday" type="datetime-local" required></b-form-input>
                            </b-col>
                            <b-col>
                                <label for="input-phone">電話</label>
                                <b-form-input v-model="account.userInformation.phone" id="input-phone" type="number" required trim></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row class="pb-3">
                            <b-col>
                                <label for="input-authority">身份</label>
                                <b-form-select id="input-authority" v-model="account.authority" :options="authorityOptions"></b-form-select>
                            </b-col>
                            <b-col>
                                <label for="input-department">系所</label>
                                <b-form-input id="input-department" disabled :value="department.name"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row class="pb-3">
                            <b-col>
                                <label for="input-address">地址</label>
                                <b-form-input v-model="account.userInformation.address" id="input-address" required trim></b-form-input>
                            </b-col>
                        </b-row>
                    </b-form-group>
                </b-form>
            </b-card>
        </b-container>
        <b-button variant="secondary" @click="submit">送出</b-button>
    </div>
</template>

<script>
    import axios from "axios";
    import NavBar from '@/components/NavBar.vue';

    export default {
        components: {
            NavBar
        },
        data() {
            return {
                department: this.$route.params.department,
                account:{
                    authority: '',
                    userInformation: {
                        name: '',
                        gender: '',
                        phone: '',
                        birthday: '',
                        address: '',
                    }
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
            async submit(){
                const vm = this;
                const api = `${process.env.VUE_APP_APIPATH}/api/admin/accounts/department/${this.department.id}`;
                const token = localStorage.getItem("token");
                const response = await axios
                    .post(
                        api,
                        this.account,
                        {headers: { "content-type": "application/json;charset=utf-8", Authorization: `Bearer ${token}`}}
                    )
                    .then((response) => {  
                        return response;
                    })
                    .catch(error =>{
                        console.log(error.response)
                        return error.response
                    });
                if(response.status >= 200 && response.status < 300){
                    console.log(response.data)
                    this.$router.push({ name: "resultOfCreateAccount", params: { account: this.account,  department: this.department} });

                } else {
                    localStorage.clear();
                    this.$router.push("/login");
                }
            },
        },
        created() {}
    }
</script>