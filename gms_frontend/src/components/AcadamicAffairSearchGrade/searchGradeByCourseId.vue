<template>
    <div>
        <NavBar />
        <div>
        <b-jumbotron class="mb-2" header="查詢結果" lead></b-jumbotron>
        </div>
        <b-container fluid class="mt-3">
        <b-row>
            <b-col>
            <b-card>
                <b-table show-empty small stacked="md" :items="gradeTable" :fields="fields">
                <template v-slot:cell(name)="row">{{ row.value }}</template>
                <template v-slot:cell(grade)="row">{{ row.item.department_name }}-{{ row.item.grade }}</template>
                </b-table>
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
      course_id: this.$route.params.course_id,
      gradeTable: null,
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
          `${process.env.VUE_APP_APIPATH}/api/students/course/${this.course_id}`,
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
        this.gradeTable = await response.data;
      } else {
          localStorage.clear()
          this.$router.push({name: "Login"})
      }
    },
    toBack() {
      this.$router.push({ name: "acadamicAffairSearchGradeMainPage" });
    }
  },
  created() {
    this.getGradeTable();
  },
  components: {
    NavBar
  }
};
</script>

<style>
</style>