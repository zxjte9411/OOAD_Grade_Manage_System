<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class="" header="選擇你要的操作" lead>
        <b-button class="mt-5 mx-2" variant="primary" @click="goSearchHistoryByCopurseId">以課程查詢成績</b-button>
        <b-button class="mt-5 mx-2" variant="primary" @click="goSearchHistoryByStudentId">以學生查詢成績</b-button>
      </b-jumbotron>
    </div>

    <b-modal id="course" title="輸入課號" hide-footer centered>
        <b-card class="mb-3">
            <b-form @submit.stop.prevent="handleSubmitForCourseId">
                <b-row>
                    <b-col>
                        <b-form-group id="course_id-group" label-for="course_id">
                            <b-form-input id="course_id" v-model="course_id" type="number" />
                        </b-form-group>
                    </b-col>
                    <b-col cols="3">
                        <b-button type="submit" pill variant="success" class="float-left">送出</b-button>
                    </b-col>
                </b-row>
            </b-form>
        </b-card>
    </b-modal>

    <b-modal id="student" title="輸入學號" hide-footer centered>
        <b-card class="mb-3">
            <b-form @submit.stop.prevent="handleSubmitForStudentId">
                <b-row>
                    <b-col>
                        <b-form-group id="student_id-group" label-for="student_id">
                            <b-form-input id="student_id" v-model="student_id" type="number" />
                        </b-form-group>
                    </b-col>
                    <b-col cols="3">
                        <b-button type="submit" pill variant="success" class="float-left">送出</b-button>
                    </b-col>
                </b-row>
            </b-form>
        </b-card>
    </b-modal>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar";

export default {
    data() {
        return {
            course_id: "",
            student_id: ""
        };
    },
    components: {
        NavBar
    },
    computed: {},
    methods: {
        goSearchHistoryByCopurseId() {
            this.$bvModal.show("course");
        },
        goSearchHistoryByStudentId() {
            this.$bvModal.show("student");
        },
        handleSubmitForCourseId() {
            this.$router.push({name: "acadamicAffairSearchGradeByCourseId", params: {course_id: this.course_id}});
        },
        handleSubmitForStudentId() {
            this.$router.push({name: "acadamicAffairSearchGradeByStudentId", params: {student_id: this.student_id}});
        },
    }
};
</script>

<style>
</style>