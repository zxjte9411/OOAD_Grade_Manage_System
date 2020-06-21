<template>
    <div>
        <NavBar />
        <b-container fluid class="pl-5 pr-5 mt-3">
            <b-row class="pb-3">
                <b-col cols="4" offset="4">
                    <b-card class="mb-3" title="建立成功！">
                        <b-form>
                            <b-form-group id="input-group-userInformation" class="text-left">

                                <label class="mt-3" for="input-name">姓名</label>
                                <b-form-input :value="account.userInformation.name" id="input-name" disabled></b-form-input>

                                <label class="mt-3" for="input-gender">性別</label>
                                <b-form-input :value="account.userInformation.gender" id="input-gender" disabled></b-form-input>

                                <label class="mt-3" for="input-birthday">生日</label>
                                <b-form-input :value="account.userInformation.birthday" id="input-birthday" disabled></b-form-input>

                                <label class="mt-3" for="input-phone">電話</label>
                                <b-form-input :value="account.userInformation.phone" id="input-phone" disabled></b-form-input>

                                <label class="mt-3" for="input-authority">身份</label>
                                <b-form-input id="input-authority" :value="authorityOptions[account.authority]" disabled></b-form-input>

                                <label class="mt-3" for="input-department">系所</label>
                                <b-form-input id="input-department" :value="department.name" disabled></b-form-input>

                                <label class="mt-3" for="input-address">地址</label>
                                <b-form-input :value="account.userInformation.address" id="input-address" disabled></b-form-input>
                            </b-form-group>
                        </b-form>
                    </b-card>
                </b-col>
            </b-row>
        </b-container>
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
                account: this.$route.params.account,
                // genderOptions:[
                //     { value: '男', text: '男' },
                //     { value: '女', text: '女' },
                // ],
                authorityOptions: {
                     0: '管理員',
                     1: '教職員',
                     2: '教　師',
                     3: '學　生'
                },
            };
        },
        methods: {},
        created() {}
    }
</script>