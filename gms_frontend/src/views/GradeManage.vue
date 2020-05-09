<template>
  <div>
    <b-container fluid class="my-3">
      <!-- Main table element -->
      <b-card v-if="selected">
        <!-- 成績表 -->
        <b-table show-empty small stacked="md" :items="students" :fields="fields">
          <template v-slot:cell(name)="row">{{ row.value }}</template>
          <template v-slot:cell(score)="row">
            <input
          </template>
        </b-table>
        <!-- 成績表 end -->
        <input type="button" value="送出" @click="submit(students)" />
      </b-card>
      <b-card v-if="!selected">
        <!-- 成績表 -->
        <ul v-for="(item, index) in courses" :key="index">
          <b-button
            variant="outline-success"
            @click="selectCourse(item.id, item.year, item.semester)"
          >{{ item.name }}</b-button>
        </ul>
        <!-- 成績表 end -->
      </b-card>
    </b-container>
  </div>
</template>

<script>
import axios from "axios";
import { async } from "q";

export default {
  data() {
    return {
      selected: false,
      students: null,
      courses: null,
      course_id: null,
      year: null,
      semester: null,
      fields: [
        {
          key: "id",
          label: "姓名",
          sortable: true,
          sortDirection: "desc"
        },
        {
          key: "name",
          label: "姓名",
          sortable: true,
          class: "text-center"
        },
        {
          key: "semester",
          label: "年級",
          sortable: true,
          sortDirection: "desc",
          class: "text-center"
        },
        {
          key: "year",
          label: "年度",
          sortable: true
          //   sortDirection: "desc",
          //   class: "text-center",
          //   formatter: (value /*, key, item*/) => {
          //     return value
          //       ? this.CharactorOptions[value].name
          //       : this.CharactorOptions[0].name;
          //   }
        },
        {
          key: "score",
          label: "分數",
          sortable: true,
          sortByFormatted: true,
          filterByFormatted: true
        }
        // { key: "actions", label: "操作" }
      ]
    };
  },
  mounted() {
    this.getTeacherCourses();
  },
  computed: {},
  methods: {
    async getStudentsData(course_id = "275689") {
      this.course_id = course_id;
      let response = await axios
        .get(
          `${process.env.VUE_APP_APIPATH}/api/students/course/${course_id}`,
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
      this.students = response.data;
      console.log(response.data);
    },
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
      console.log(response.data);
    },
    async submit() {
      const data = {};
      this.students.forEach(student => {
        data[student.id] = student.score
      });
      let response = await axios
        .post(
          `${process.env.VUE_APP_APIPATH}/api/students/grade/${this.course_id}/${this.year}/${this.semester}`,
          data,
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
          return await err;
        });
        console.log(response)
    },
    selectCourse(course_id, year, semester) {
      console.log([course_id, year, semester]);
      this.course_id = course_id;
      this.year = year;
      this.semester = semester;
      this.selected = !this.selected;
      this.getStudentsData(course_id);
    },
    print(p) {
      this.selected = !this.selected;
      console.log(p);
    }
  }
};
</script>

<style>
</style>