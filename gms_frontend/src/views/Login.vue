<template>
    <b-container fluid class="d-flex justify-content-center" :style="styleObject">
      <b-row class="text-center mt-5">
        <b-form @submit.prevent="login">
          <!-- <img src="@/assets/logo.png" alt class="mb-3" width="160" height="80"> -->
          <img class="mb-3" src="https://img.icons8.com/material/144/000000/padlock-outline.png"/>
          <b-card-group>
            <b-card title="登入">
              <b-form-group
                id="fieldset-userID"
                label="Enter your account Id"
                label-for="input-userID"
                :invalid-feedback="invalidUserIDFeedback"
                :valid-feedback="validFeedback"
                :state="userIDState"
              >
                <b-form-input
                  id="account"
                  v-model="userID"
                  :state="userIDState"
                  type="text"
                  trim
                  required
                ></b-form-input>
              </b-form-group>

              <b-form-group
                id="fieldset-password"
                label="Enter your password"
                label-for="input-password"
                :invalid-feedback="invalidPasswordFeedback"
                :valid-feedback="validFeedback"
                :state="passwordState"
              >
                <b-form-input
                  id="password"
                  v-model="password"
                  :state="passwordState"
                  type="password"
                  trim
                  required
                ></b-form-input>
              </b-form-group>
              <b-button type="submit" :disabled="!btnLoginEnabled">Login In</b-button>
              <b-modal id="Alertmodal" ref="AlertModal" ok-only centered>
                <b-alert class="left" show variant="danger">"wrong account or password"</b-alert>
              </b-modal>
            </b-card>
          </b-card-group>
          <p class="mt-5 mb-3 text-muted">© 2020-202</p>
        </b-form>
      </b-row>
    </b-container>
</template>
<script>
import { async } from "q";
const axios = require("axios").default;

export default {
  data() {
    return {
      styleObject:{
        "background-color": "#f5f5f5",
        "position": "fixed",
        height: "100%"
      },
      userID: "",
      password: "",
      isPasswordOrUserIDError: false
    };
  },
  mounted() {
    if (localStorage.getItem("token") !== null) {
      this.gotToCorrectPage();
    }
  },
  components: {},
  methods: {
    async login() {
      // write login authencation logic here!
      let res = await axios
        .post(
          `${process.env.VUE_APP_APIPATH}/token`,
          { id: this.userID, password: this.password },
          { headers: { "content-type": "application/json;charset=utf-8" } }
        )
        .then(async function(res) {
          return res;
        })
        .catch(async function(err) {
          console.log(err);
          return err;
        });
      if (res.status >= 200 && res.status < 300) {
        localStorage.setItem("token", res.data.token);
        localStorage.setItem("user_id", res.data.id);
        localStorage.setItem("authority", res.data.authority);
        this.isPasswordOrUserIDError = false;
        this.gotToCorrectPage();
      } else {
        this.isPasswordOrUserIDError = true;
        this.$refs.AlertModal.show();
      }
    },
    gotToCorrectPage() {
      const authority = localStorage.getItem("authority");
      if (authority === "0") {
        this.$router.push("/accountmanage");
      }
      if (authority === "1") {
        this.$router.push("/");
      }
      if (authority === "2") {
        this.$router.push("/grademanage");
      }
      if (authority === "3") {
        this.$router.push("/grademanage");
      }
    }
  },
  computed: {
    btnLoginEnabled() {
      return (
        this.userIDState && this.passwordState && !this.isPasswordOrUserIDError
      );
    },
    userIDState() {
      return this.userID.length >= 4 && !this.isPasswordOrUserIDError;
    },
    passwordState() {
      return this.password.length >= 4 && !this.isPasswordOrUserIDError;
    },
    invalidUserIDFeedback() {
      if (this.userID.length >= 4) {
        this.isPasswordOrUserIDError = false;
        return "";
      } else if (this.userID.length > 0) {
        this.isPasswordOrUserIDError = true;
        return "Enter at least 4 characters";
      } else {
        this.isPasswordOrUserIDError = true;
        return "Please enter something";
      }
    },
    invalidPasswordFeedback() {
      if (this.password.length >= 4) {
        this.isPasswordOrUserIDError = false;
        return "";
      } else if (this.password.length > 0) {
        this.isPasswordOrUserIDError = true;
        return "Enter at least 4 characters";
      } else {
        this.isPasswordOrUserIDError = true;
        return "Please enter something";
      }
    },
    validFeedback() {
      // return this.state === true ? "Thank you" : "";
    }
  }
};
</script>
