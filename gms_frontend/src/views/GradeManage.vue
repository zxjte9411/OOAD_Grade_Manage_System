<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class header="選擇你要的操作" lead>
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
        return {};
    },
    components: {
        NavBar
    },
    methods: {
        goSearchHistory() {
        this.$router.push("/grademanage/searchgrade");
        },
        goSelectCourse() {
        this.$router.push("/grademanage/course");
        }
    }
};
</script>
<style>
</style>