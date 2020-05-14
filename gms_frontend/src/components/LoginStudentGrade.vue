<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class="mb-2" header="成績登錄" lead></b-jumbotron>
    </div>
    <b-container fluid class="mt-3">
      <b-row>
        <b-col>
          <b-card>
            <h1>{{course.name}}</h1>
            <!-- 成績表 -->
            <b-table show-empty small stacked="md" :items="students" :fields="fields">
              <template v-slot:cell(name)="row">{{ row.value }}</template>
              <template v-slot:cell(grade)="row">{{ row.item.department_name }}-{{ row.item.grade }}</template>
              <template v-slot:cell(score)="row">
                <input
                  type="number"
                  min="1"
                  max="100"
                  v-model.number="row.item.score"
                  value="row.item.score"
                  :disabled="!canEdit"
                  :style="row.item.textColor"
                />
              </template>
            </b-table>
            <!-- 成績表 end -->
            <b-button variant="success" @click="checkScore()" v-if="canEdit">送出</b-button>
            <b-button variant="warning" @click="canEdit=!canEdit" v-if="!canEdit">編輯</b-button>
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
      canEdit: false,
      messages: [],
      course: this.$route.params.course,
      students: null,
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
          label: "班級",
          sortable: true,
          sortDirection: "desc",
          class: "text-center"
        },
        {
          key: "score",
          label: "分數",
          sortable: true
        }
      ]
    };
  },
  methods: {
    async getGradeTable() {
      let response = await axios
        .get(
          `${process.env.VUE_APP_APIPATH}/api/students/course/${this.course.id}`,
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
        this.students = await response.data;
      }
    },
    checkScore() {
      let isCanSubmit = true;
      this.messages.length = 0;
      const vm = this;
      this.students.forEach(function(student) {
        if (!/^\d{1,3}$/.test(student.score)) {
          student["textColor"] = "color:red";
          vm.messages.push(`學號：${student.id}，成績格式有誤`);
          isCanSubmit = false;
        }
      });
      if (isCanSubmit) {
        this.submit();
      } else {
        this.$refs.AlertModal.show();
      }
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
          `${process.env.VUE_APP_APIPATH}/api/students/grade/${this.course.id}/`,
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
      this.toBack();
    },
    toBack() {
      this.$router.push("/grademanage/course");
    }
  },
  created() {
    console.log(this.course);
    this.getGradeTable();
  },
  components: {
    NavBar
  }
};
</script>

<style>
</style>