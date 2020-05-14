<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class="mb-2" header="選擇你要登錄的課程" lead></b-jumbotron>
    </div>
    <b-container>
      <b-row>
        <b-col>
          <b-card>
            <!-- 課程選單 -->
            <h1>{{YEAR}}-{{SEMESTER}}</h1>
            <div v-for="(item, index) in courses" :key="index" class="my-2">
              <b-button
                class="ml-0"
                variant="outline-success"
                v-if="item.year==YEAR&&item.semester==SEMESTER"
                @click="selectCourse(item)"
              >{{ item.name }}</b-button>
            </div>
            <b-button variant="primary" @click="goBack" class="mx-2">返回</b-button>
            <!-- 課程選單 end -->
          </b-card>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar";
import axios from "axios";

export default {
  data() {
    return {
      courses: null,
      YEAR: null,
      SEMESTER: null
    };
  },
  methods: {
    async getTeacherCourses(teacher_id = "54321") {
      let response = await axios
        .get(
          `${process.env.VUE_APP_APIPATH}/api/teachers/${teacher_id}/courses`,
          {
            headers: {
              "content-type": "application/json;charset=utf-8"
            }
          }
        )
        .then(async res => {
          return await res;
        })
        .catch(async err => {
          return await err.response;
        });
      this.courses = response.data;
    },
    selectCourse(course) {
      this.$router.push({
        name: "LoginGrade",
        params: { course: course }
      });
    },
    goBack() {
      this.$router.push("/grademanage/");
    }
  },
  mounted() {
    this.YEAR = 108;
    this.SEMESTER = 2;
    this.getTeacherCourses(localStorage.getItem("user_id"));
  },
  components: { NavBar }
};
</script>

<style>
</style>