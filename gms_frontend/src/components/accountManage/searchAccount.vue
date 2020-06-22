<template>
    <div>
        <NavBar />
        <b-container fluid class="my-3">
            <b-row>
                <b-col lg="4" class="my-1">
                    <h1>查看帳號：{{ department.name }}</h1>
                </b-col>
                <b-col lg="8" class="my-1"></b-col>
            </b-row>
            <b-card>
            <!-- User Interface controls -->
                <b-row class="mb-4">
                    <b-col lg="6" class="my-1">
                        <b-form-group label="Sort" label-cols-sm="3" label-align-sm="right" label-size="sm" label-for="sortBySelect" class="mb-0">
                            <b-input-group size="sm">
                                <b-form-select v-model="sortBy" id="sortBySelect" :options="sortOptions" class="w-75">
                                    <template v-slot:first>
                                        <option value>-- none --</option>
                                    </template>
                                </b-form-select>
                                <b-form-select v-model="sortDesc" size="sm" :disabled="!sortBy" class="w-25">
                                    <option :value="false">Asc</option>
                                    <option :value="true">Desc</option>
                                </b-form-select>
                            </b-input-group>
                        </b-form-group>
                    </b-col>
                    <!-- User Interface controls END -->
                    <!-- 初始排序方式 -->
                    <b-col lg="6" class="my-1">
                        <!-- <b-form-group label="Initial sort" label-cols-sm="3" label-align-sm="right" label-size="sm" label-for="initialSortSelect" class="mb-0">
                            <b-form-select v-model="sortDirection" id="initialSortSelect" size="sm" :options="['asc', 'desc', 'last']" ></b-form-select>
                        </b-form-group> -->
                    </b-col>
                    <!-- 初始排序方式 END-->
                    <!-- 輸入搜尋 -->
                    <b-col lg="6" class="my-1">
                        <b-form-group label="Filter" label-cols-sm="3" label-align-sm="right" label-size="sm" label-for="filterInput" class="mb-0">
                            <b-input-group size="sm">
                                <b-form-input v-model="filter" type="search" id="filterInput" placeholder="Type to Search"></b-form-input>
                                    <b-input-group-append>
                                        <b-button :disabled="!filter" @click="filter = ''">Clear</b-button>
                                    </b-input-group-append>
                            </b-input-group>
                        </b-form-group>
                    </b-col>
                    <!-- 輸入搜尋 END -->
                    <!-- 勾選要過濾的欄位 -->
                    <b-col lg="6" class="my-1"> 
                        <b-form-group label="Filter On" label-cols-sm="3" label-align-sm="right" label-size="sm" description="Leave all unchecked to filter on all data" class="mb-0">
                            <b-form-checkbox-group v-model="filterOn" class="mt-1">
                                <b-form-checkbox value="name">使用者名稱</b-form-checkbox>
                                <b-form-checkbox value="id">使用者帳號</b-form-checkbox>
                                <b-form-checkbox value="gender">性別</b-form-checkbox>
                            </b-form-checkbox-group>
                        </b-form-group>
                    </b-col>
                    <!-- 勾選要過濾的欄位 END -->

                    <!-- 設定每頁顯示數量 下拉選單-->
                    <b-col sm="5" md="6" class="my-1">
                        <b-form-group label="Per page" label-cols-sm="6" label-cols-md="4" label-cols-lg="3" label-align-sm="right" label-size="sm" label-for="perPageSelect" class="mb-0">
                            <b-form-select v-model="perPage" id="perPageSelect" size="sm" :options="pageOptions"></b-form-select>
                        </b-form-group>
                    </b-col>
                    <!-- 設定每頁顯示數量 END-->

                    <!-- 選擇頁數按鈕 -->
                    <b-col sm="7" md="6" class="my-1">
                        <b-pagination v-model="currentPage" :total-rows="totalRows" :per-page="perPage" align="fill" size="sm" class="my-0"></b-pagination>
                    </b-col>
                    <!-- 選擇頁數按鈕 END -->
                </b-row>
                <!-- Main table element -->
                <b-table show-empty small stacked="md" :items="items" :fields="fields" :current-page="currentPage" :per-page="perPage" :filter="filter" :filterIncludedFields="filterOn" :sort-by.sync="sortBy" :sort-desc.sync="sortDesc" :sort-direction="sortDirection" @filtered="onFiltered">
                    <template v-slot:cell(name)="row">{{ row.value }}</template>
                    <template v-slot:cell(actions)="row">
                        <b-button size="sm" @click="info(row.item, row.index, $event.target)" variant="success" class="mr-1">編輯</b-button>
                        <b-button size="sm" @click="detail(row.item, row.index, $event.target)" variant="info" class="mr-1">詳細</b-button>
                        <!-- <b-button size="sm" @click="row.toggleDetails" variant="info" class="mr-1">{{ row.detailsShowing ? '隱藏' : '顯示' }}詳細</b-button> -->
                        <!-- <b-button size="sm" @click="deleteItem=row.item" v-b-modal.check-delete-modal variant="danger" >刪除</b-button> -->
                    </template>
                    <template v-slot:row-details="row">
                        <b-card>
                            <ul class="text-left">
                                <li v-for="(value, key) in row.item" :key="key">{{ key }}: {{ value }}</li>
                            </ul>
                        </b-card>
                    </template>
                </b-table>
                
                <!-- Info modal -->
                <b-modal :id="infoModal.id" title="編輯" hide-footer @hide="resetInfoModal" centered>
                    <b-form ref="form" @submit.stop.prevent="handleSubmit">
                        <b-form-group id="name-group" label="姓名" label-for="name" description="修改姓名">
                            <b-form-input id="name" v-model="newData.userInformation.name" required />
                        </b-form-group>
                        <b-form-group id="authority-group" label="身份" label-for="authority" description="修改身份" >
                            <b-form-select v-model="newData.authority" :options="authorityOptions" value-field="authority" text-field="name" disabled></b-form-select>
                        </b-form-group>
                        <b-form-group id="phone-group" label="電話" label-for="phone" description="修改電話" >
                            <b-form-input id="phone" v-model="newData.userInformation.phone" />
                        </b-form-group>
                        <b-form-group id="address-group" label="地址" label-for="address" description="修改地址" >
                            <b-form-input id="address" v-model="newData.userInformation.address" />
                        </b-form-group>
                        <b-form-group id="birthday-group" label="生日" label-for="birthday" description="修改生日" >
                            <b-form-input id="birthday" v-model="newData.userInformation.birthday" />
                        </b-form-group>
                        <b-form-group id="gender-group" label="性別" label-for="gender" description="修改性別">
                            <b-form-select id="gender" v-model="newData.userInformation.gender" :options="genderOptions" value-field="gender" text-field="name" required />
                        </b-form-group>
                        <b-button type="submit" pill variant="success" class="float-right">送出</b-button>
                    </b-form>
                </b-modal>
                <!-- Info modal END-->
                <!-- detail modal -->
                <b-modal id="detail" title="詳細資料" hide-footer @hide="resetInfoModal" centered>
                    <b-form ref="form" @submit.stop.prevent="handleSubmit">
                        <b-form-group id="name-group" label="姓名" label-for="name">
                            <b-form-input id="name" v-model="newData.userInformation.name" disabled />
                        </b-form-group>
                        <b-form-group id="authority-group" label="身份" label-for="authority">
                            <b-form-select v-model="newData.authority" :options="authorityOptions" value-field="authority" text-field="name" disabled></b-form-select>
                        </b-form-group>
                        <b-form-group id="phone-group" label="電話" label-for="phone">
                            <b-form-input id="phone" v-model="newData.userInformation.phone" disabled />
                        </b-form-group>
                        <b-form-group id="address-group" label="地址" label-for="address">
                            <b-form-input id="address" v-model="newData.userInformation.address" disabled />
                        </b-form-group>
                        <b-form-group id="birthday-group" label="生日" label-for="birthday">
                            <b-form-input id="birthday" v-model="newData.userInformation.birthday" disabled />
                        </b-form-group>
                        <b-form-group id="gender-group" label="性別" label-for="gender">
                            <b-form-input id="gender" v-model="newData.userInformation.gender" :options="genderOptions" value-field="gender" text-field="name" disabled />
                        </b-form-group>
                    </b-form>
                </b-modal>
                <!-- detail modal END-->
                <!-- check delete modal-->
                <!-- <b-modal id="check-delete-modal" hide-footer>
                    <b-alert show variant="warning" class="text-center">確定刪除？</b-alert>
                    <b-button class="float-right" @click="deleteAccount(false)">取消</b-button>
                    <b-button variant="danger" class="float-right mr-2" @click="deleteAccount(true)">確定</b-button>
                </b-modal> -->
                <!-- check delete modal END-->
            </b-card>
            <b-button variant="primary" @click="goBack" class="mt-4">返回</b-button>
        </b-container>
    </div>
</template>

<script>
import NavBar from "@/components/NavBar.vue";
import axios from "axios";

export default {
    data() {
        return {
            department: this.$route.params.department,
            newData: {
                id: "",
                password: "",
                authority: "",
                userInformation: {    
                    name: "",
                    phone: "",
                    address: "",
                    birthday: "",
                    gender: ""
                },
            },
            CharactorSelect: 1,
            items: [],
            fields: [
                {
                    key: "userInformation.name",
                    label: "使用者名稱",
                    sortable: true,
                    sortDirection: "desc"
                },
                {
                    key: "id",
                    label: "使用者帳號",
                    sortable: true,
                    class: "text-center"
                },
                // {
                //     key: "password",
                //     label: "使用者密碼",
                //     sortable: true,
                //     sortDirection: "desc",
                //     class: "text-center"
                // },
                {
                    key: "authority",
                    label: "使用者權限",
                    sortable: true,
                    sortDirection: "desc",
                    class: "text-center",
                    formatter: (value /*, key, item*/) => {
                        return value
                        ? this.authorityOptions[value].name
                        : this.authorityOptions[0].name;
                    }
                },
                {
                    key: "userInformation.gender",
                    label: "性別",
                    sortable: true,
                    sortByFormatted: true,
                    filterByFormatted: true
                },
                { key: "actions", label: "操作" }
            ],
            authorityOptions: [
                { authority: 0, name: "管理員"},
                { authority: 1, name: "教職員"},
                { authority: 2, name: "教　師"},
                { authority: 3, name: "學　生"},
                { authority: 4, name: "未設定"},
            ],
            genderOptions: [
                { gender: "男", name: "男"},
                { gender: "女", name: "女"},
            ],
            totalRows: 1,
            currentPage: 1,
            perPage: 10,
            pageOptions: [10, 15, 20],
            sortBy: "account",
            sortDesc: false,
            sortDirection: "asc",
            filter: null,
            filterOn: [],
            infoModal: {
                id: "info-modal",
                title: "",
                content: ""
            },
            deleteItem: null
        };
    },
    computed: {
        sortOptions() {
            // Create an options list from our fields
            return this.fields
                .filter(f => f.sortable)
                .map(f => {return { text: f.label, value: f.key }});
        }
    },
    components: {
        NavBar,
    },
    mounted() {
        // Set the initial number of items
        this.fetchData();
    },
    methods: {
        info(item, index, button) {
            // console.log(item)
            this.newData.id = item.id;
            this.newData.password = item.password;
            this.newData.authority = item.authority;
            this.infoModal.title = item.userInformation.name;
            this.newData.userInformation.name = item.userInformation.name;
            this.newData.userInformation.phone = item.userInformation.phone;
            this.newData.userInformation.address = item.userInformation.address;
            this.newData.userInformation.birthday = item.userInformation.birthday;
            this.newData.userInformation.gender = item.userInformation.gender;
            this.infoModal.content = JSON.stringify(item, null, 2);
            // this.$root.$emit("bv::show::modal", this.infoModal.id, button);
            this.$bvModal.show(this.infoModal.id);
        },
        detail(item, index, button){
            this.newData.authority = item.authority;
            this.newData.userInformation.name = item.userInformation.name;
            this.newData.userInformation.phone = item.userInformation.phone;
            this.newData.userInformation.address = item.userInformation.address;
            this.newData.userInformation.birthday = item.userInformation.birthday;
            this.newData.userInformation.gender = item.userInformation.gender;
            this.$bvModal.show("detail");
        },
        resetInfoModal() {
            this.infoModal.title = "";
            this.infoModal.content = "";
            this.newData = {
                id: "",
                password: "",
                authority: "",
                userInformation: {    
                    name: "",
                    phone: "",
                    address: "",
                    birthday: "",
                    gender: ""
                }
            };
        },
        onFiltered(filteredItems) {
            // Trigger pagination to update the number of buttons/pages due to filtering
            this.totalRows = filteredItems.length;
            this.currentPage = 1;
        },
        async fetchData() {
            const token = localStorage.getItem("token");
            let res = await axios
                .get(`${process.env.VUE_APP_APIPATH}/api/admin/accounts/department/${this.$route.params.department.id}`, {
                headers: { "content-type": "application/json;charset=utf-8", Authorization: `Bearer ${token}`}})
                .then(async res => {
                    return await res;
                })
                .catch(async err => {
                    return await err.response;
                });
            if (res.status == 401) {
                localStorage.clear()
                this.$router.push("/login");
            }
            this.items = res.data;
            this.totalRows = this.items.length;
        },
        async handleSubmit() {
            const data = this.newData.userInformation;
            const token = localStorage.getItem("token");
            let res = await axios
                .post(
                `${process.env.VUE_APP_APIPATH}/api/admin/accounts/department/${this.department.id}/${this.newData.id}`,
                data,
                { headers: { "content-type": "application/json;charset=utf-8", Authorization: `Bearer ${token}`}})
                .then(async res => {
                    return await res;
                })
                .catch(async err => {
                    console.log(err);
                    return await err.response;
                });
            // console.log(this.newData)
            if (res.status == 200) {
                this.fetchData();
                this.$bvModal.hide(this.infoModal.id);
            } else {
                localStorage.clear();
                this.$router.push("/login");
            }
        },
        async deleteAccount(isCanDelete) {
            this.$bvModal.hide("check-delete-modal");
            if (isCanDelete) {
                const token = localStorage.getItem("token");
                let res = await axios
                    .delete(
                        `${process.env.VUE_APP_APIPATH}/api/user/${this.deleteItem.id}`,
                        { headers: { "content-type": "application/json;charset=utf-8", Authorization: `Bearer ${token}`}})
                    .then(async res => {
                        this.fetchData();
                        this.deleteItem = null;
                        this.makeToast("success", "刪除成功！", "成功");
                        return await res;
                    })
                    .catch(async err => {
                        this.makeToast("danger","刪除失敗...","失敗","b-toaster-bottom-full");
                        return await err.response;
                    });
            }
        },
        openAddModal() {
            this.$bvModal.show("addAccountModal");
        },
        makeToast(variant = null, message = "", title = "", toaster = "b-toaster-top-right") {
            this.$bvToast.toast(message, { title: title, toaster: toaster, variant: variant, solid: true});
        },
        goBack(){
            this.$router.push({ name: "selectdepartment", params: {operation: this.$route.params.operation, department: this.department} });
        },
    }
};
</script>