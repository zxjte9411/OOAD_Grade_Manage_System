<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="primary" class="px-5 py-3">
      <router-link to="/">
        <b-navbar-brand class="ml-5" v-if="isAdmin">帳號管理</b-navbar-brand>
        <b-navbar-brand class="ml-5" v-if="!isAdmin">成績管理</b-navbar-brand>
      </router-link>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <!-- <b-navbar-nav class="mr-auto">
          <b-nav-item v-if="isAdmin" href="/accountmanage">Accountmanage</b-nav-item>
          <b-nav-item v-if="!isAdmin" href="/grademanage">Grademanage</b-nav-item>
        </b-navbar-nav> -->
        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-item id="user-name">Hi，{{userName}}</b-nav-item>
          <b-nav-item @click="logout" id="user-name">登出</b-nav-item>
          <!-- <b-nav-item-dropdown class="mr-5" right>
            <template v-slot:button-content>
              <font-awesome-icon icon="user" size="lg" />
            </template>
            <b-dropdown-item @click="logout">Sign Out</b-dropdown-item>
          </b-nav-item-dropdown> -->
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "NavBar",
  data() {
    return {
      userName: "",
      isAdmin: false
    };
  },
  methods: {
    logout() {
      localStorage.clear();
      this.$router.push("/login");
    },
    async CheckIdentity() {
      const user_id = localStorage.getItem("user_id");
      const token = localStorage.getItem("token");
      const authority = localStorage.getItem("authority");
      if (token !== null) {
        this.isAdmin = true;
        if (authority != "0") {
          this.isAdmin = false;
        }
      }
      const api = `${process.env.VUE_APP_APIPATH}/api/admin/accounts/${user_id}`;
      const vm = this;
      let res = await axios
        .get(api, {
          headers: {
            Authorization: `Bearer ${token}`,
            "content-type": "application/json;charset=utf-8"
          }
        })
        .then(res => {
          return res;
        })
        .catch(err => {
          return err.response;
        });
      if (res.status >= 200 && res.status < 300) {
        this.userName = res.data.userInformation.name;
      } else {
        localStorage.clear();
        this.$router.push("/");
      }
    }
  },
  mounted() {
    this.CheckIdentity();
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
/* .navbar {
  max-width: 41em; 
  margin: auto; 
  padding: 1em; 
  font-size: 108%;
} */
</style>
