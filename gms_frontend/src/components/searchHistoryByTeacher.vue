<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class="mb-2" header="選擇你要查詢的課程" lead></b-jumbotron>
    </div>
    <b-container fluid class="mt-3">
      <b-row>
        <b-col>
          <b-card>
            <div v-for="(items, index) in courses" :key="index" class="my-2">
              <h2>{{ index }}</h2>
              <div v-for="(item, i) in items" :key="i" class="my-2">
                <b-button
                  class="ml-0"
                  variant="outline-success"
                  @click="selectCourse(item)"
                >{{ item.name }}</b-button>
              </div>
            </div>
            <b-button variant="primary" @click="toBack" class="mx-2">返回</b-button>
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
      courses: null
    };
  },
  mounted() {
    this.getTeacherCourses(localStorage.getItem("user_id"));
  },
  methods: {
    async getTeacherCourses(teacher_id = 12345) {
      let response = await axios
        .get(
          `${process.env.VUE_APP_APIPATH}/api/teachers/${teacher_id}/courses`,
          {
            headers: {
              "content-type": "application/json;charset=utf-8"
            }
          }
        )
        .then(async function(res) {
          return await res;
        })
        .catch(async function(err) {
          return await err;
        });
      if (response.status >= 200 && response.status < 300) {
        // response.data;
        let temp = {};
        response.data.forEach(function(item) {
          if (temp[`${item.year}-${item.semester}`] !== undefined) {
            temp[`${item.year}-${item.semester}`].push(item);
          } else {
            temp[`${item.year}-${item.semester}`] = [];
            temp[`${item.year}-${item.semester}`].push(item);
          }
        });
        this.courses = temp;
      }
    },
    selectCourse(course) {
      this.$router.push({ name: "resultOfSearchgrade", params: { course: course } });
    },
    toBack() {
      this.$router.push("/grademanage");
    }
  },
  components: {
    NavBar
  }
};
</script>

<style>
</style>