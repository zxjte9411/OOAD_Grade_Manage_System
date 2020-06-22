<template>
  <div>
    <NavBar />
    <div>
      <div>
        <b-jumbotron class="mb-2" header="選擇系所" lead></b-jumbotron>
      </div>
      <b-container fluid class="mt-3">
        <b-row>
          <b-col>
            <b-card class="d-flex">
              <div>
                <b-button v-for="(department, index) in departments" :key="index" class="mx-2"
                  variant="outline-success"
                  @click="selectDepartment(department)"
                >{{ department.name }}</b-button>
              </div>
              <b-button variant="primary" @click="goBack" class="mt-4">返回</b-button>
            </b-card>
          </b-col>
        </b-row>
      </b-container>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import NavBar from "@/components/NavBar";
import Register from "@/components/accountManage/Register.vue";

export default {
  data() {
    return {
      operation: this.$route.params.operation,
      departments: []
    };
  },
  mounted() {
    this.getAllDepartments();
  },
  methods: {
    async getAllDepartments() {
      const token = localStorage.getItem("token");
      let res = await axios
        .get(`${process.env.VUE_APP_APIPATH}/api/department`, {
          headers: {
            "content-type": "application/json;charset=utf-8",
            Authorization: `Bearer ${token}`
          }
        })
        .then(async res => {
          return await res;
        })
        .catch(async err => {
          console.log(err);
          return await err.response;
        });
      if (res.status == 401) {
        localStorage.clear();
        this.$router.push("/login");
      } else {
        for (var department in res.data) {
          this.departments.push({
            id: department,
            name: res.data[department]
          });
        }
      }
    },
    selectDepartment(department){
      if (this.operation === 0) // 建立帳號
        this.$router.push({ name: "createAccount", params: { department: department, operation: this.operation } });
      else if (this.operation === 1) // 查詢帳號
        this.$router.push({ name: "searchAccount", params: { department: department, operation: this.operation } });
      else if (this.operation === 2) // 編輯帳號
        this.$router.push({ name: "editAccount", params: { department: department, operation: this.operation } });
    },
    goBack() {
      this.$router.push("/accountmanage");
    }
  },
  components: {
    NavBar
  }
};
</script>

<style>
</style>