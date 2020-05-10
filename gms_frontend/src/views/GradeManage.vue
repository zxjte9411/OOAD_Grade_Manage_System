<template>
  <div>
    <NavBar />
    <div v-if="isOptionsShow">
      <b-jumbotron class="mb-2" header="選擇你要的操作" lead>
        <b-button class="mt-2 mx-2" variant="primary" @click="isOptionsShow=!isOptionsShow">成績登入</b-button>
        <b-button class="mt-2 mx-2" variant="primary" @click="isOptionsShow=!isOptionsShow">成績登入</b-button>
        <b-button class="mt-2 mx-2" variant="primary" @click="isOptionsShow=!isOptionsShow">成績登入</b-button>
        <b-button class="mt-2 mx-2" variant="primary" @click="isOptionsShow=!isOptionsShow">成績登入</b-button>
      </b-jumbotron>
    </div>
    <div v-if="!isOptionsShow&&!selected">
      <b-jumbotron class="mb-2" header="選擇你要登錄的課程" lead></b-jumbotron>
    </div>
    <b-container fluid class="mt-3">
      <b-row>
        <b-col>
          <!-- Main table element -->
          <b-card v-if="selected">
            <h1>{{course_name}}</h1>
            <!-- 成績表 -->
            <b-table show-empty small stacked="md" :items="students" :fields="fields">
              <template v-slot:cell(name)="row">{{ row.value }}</template>
              <template v-slot:cell(grade)="row">{{ row.item.department_name }} {{ row.item.grade }}</template>
              <template v-slot:cell(score)="row">
                <input
                  type="number"
                  min="1"
                  max="100"
                  v-model.number="row.item.score"
                  value="row.item.score"
                  :disabled="!canEdit"
                />
              </template>
            </b-table>
            <!-- 成績表 end -->
            <b-button variant="success" @click="submit()" v-if="canEdit">送出</b-button>
            <b-button variant="warning" @click="canEdit=!canEdit" v-if="!canEdit">編輯</b-button>
            <b-button
              variant="primary"
              @click="selected=false;canEdit=false;isOptionsShow=false"
              class="mx-2"
            >返回</b-button>
          </b-card>
        </b-col>
      </b-row>

      <b-row>
        <b-col>
          <b-card v-if="!isOptionsShow&&!selected">
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
            <b-button
              variant="primary"
              @click="selected=false;canEdit=false;isOptionsShow=true"
              class="mx-2"
            >返回</b-button>
            <!-- 課程選單 end -->
          </b-card>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import axios from "axios";
import { async } from "q";
import NavBar from "@/components/NavBar";
import Options from "@/components/Options";

export default {
  data() {
    return {
      isOptionsShow: true,
      selected: false,
      canEdit: false,
      students: null,
      courses: null,
      course_id: null,
      year: null,
      semester: null,
      YEAR: null,
      SEMESTER: null,
      fields: [
        {
          key: "id",
          label: "學號",
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
          key: "grade",
          label: "年級",
          sortable: true,
          sortDirection: "desc",
          class: "text-center"
        },
        // {
        //   key: "year",
        //   label: "年度",
        //   sortable: true
        //   //   sortDirection: "desc",
        //   //   class: "text-center",
        //   //   formatter: (value /*, key, item*/) => {
        //   //     return value
        //   //       ? this.CharactorOptions[value].name
        //   //       : this.CharactorOptions[0].name;
        //   //   }
        // },
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
    this.YEAR = "108";
    this.SEMESTER = 2;
  },
  components: {
    NavBar,
    Options
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
    },
    async submit() {
      this.selected = false;
      this.canEdit = false;
      this.isOptionsShow = false;
      const data = {};
      this.students.forEach(student => {
        data[student.id] = student.score.toString();
      });
      await axios
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
    },
    selectCourse(item) {
      this.course_id = item.id;
      this.year = item.year;
      this.semester = item.semester;
      this.course_name = item.name;
      this.selected = !this.selected;
      this.getStudentsData(this.course_id);
    },
    print(p) {
      console.log(p);
    }
  }
};
</script>

<style>
</style>