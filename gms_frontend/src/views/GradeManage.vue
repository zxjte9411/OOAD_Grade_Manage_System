<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class="" header="選擇你要的操作" lead>
        <b-button class="mt-5 mx-2" variant="primary" @click="goSelectCourse">成績登入</b-button>
        <b-button class="mt-5 mx-2" variant="primary" @click="goSearchHistory">歷史成績查詢</b-button>
      </b-jumbotron>
    </div>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar";

export default {
  data() {
    return {
      // fields: [
      //   {
      //     key: "id",
      //     label: "學號",
      //     sortable: true,
      //     sortDirection: "desc"
      //   },
      //   {
      //     key: "name",
      //     label: "姓名",
      //     sortable: true,
      //     class: "text-center"
      //   },
      //   {
      //     key: "grade",
      //     label: "班級",
      //     sortable: true,
      //     sortDirection: "desc",
      //     class: "text-center"
      //   },
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
      // {
      //   key: "score",
      //   label: "分數",
      //   sortable: true,
      //   sortByFormatted: true,
      //   filterByFormatted: true
      // }
      // { key: "actions", label: "操作" }
      // ]
    };
  },
  components: {
    NavBar
  },
  computed: {},
  // watch: {
  //   students: {
  //     handler: function(val, oldVal) {
  //       val.forEach(function(v, index) {
  //         if (v.score < 0) {
  //           val[index].textColor = "color:red";
  //         } else {
  //           val[index].textColor = "color:black";
  //         }
  //       });
  //     },
  //     deep: true
  //   }
  // },
  methods: {
    goSearchHistory() {
      this.$router.push("/grademanage/searchgrade");
    },
    goSelectCourse() {
      this.$router.push("/grademanage/course");
    },
  }
};
</script>

<style>
</style>