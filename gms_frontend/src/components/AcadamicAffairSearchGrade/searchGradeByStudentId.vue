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
                >{{ item.course_name }}</b-button>
              </div>
            </div>
            <b-button variant="primary" @click="toBack" class="mx-2">返回</b-button>
          </b-card>
        </b-col>
      </b-row>
    </b-container>
    <b-modal id="scoreDetail" :title="tittle" hide-footer centered>
        <b-card class="mb-3" >
            <b-form>
                <b-form-group id="input-group-userInformation" class="text-left">
                    <b-row>
                        <b-col>
                            <label class="mt-3" for="input-course_id">課號</label>
                            <b-form-input v-model="course.course_id" id="input-course_id" disabled></b-form-input>
                        </b-col>
                        <b-col>
                            <label class="mt-3" for="input-course_name">課程名稱</label>
                            <b-form-input v-model="course.course_name" id="input-course_name" disabled></b-form-input>
                        </b-col>
                        <b-col>
                            <label class="mt-3" for="input-score">分數</label>
                            <b-form-input v-if="course.score<60" v-model="course.score" id="input-score" disabled style="color:red"></b-form-input>
                            <b-form-input v-else v-model="course.score" id="input-score" disabled></b-form-input>
                        </b-col>
                    </b-row>
                </b-form-group>
            </b-form>
        </b-card>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";
import NavBar from "@/components/NavBar";

export default {
    data(){
        return{
            courses: null,
            course: {},
            tittle: ""
        }
    },
    created() {
        this.getStudentsHistory(this.$route.params.student_id);
    },
    computed:{

    },
    components: {
        NavBar,
    },
    methods: {
        async getStudentsHistory(user_id = 12345) {
        let response = await axios
            .get(
            `${process.env.VUE_APP_APIPATH}/api/students/history/${user_id}`,
            {headers: {"content-type": "application/json;charset=utf-8"}})
            .then(async function(res) {
                return await res;
            })
            .catch(async function(err) {
                console.log(err)
                return await err;
            });
            if (response.status >= 200 && response.status < 300) {
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
            } else {
                localStorage.clear()
                this.$router.push({name: "Login"})
            }
        },
        selectCourse(course) {
            this.course = course
            this.tittle = `${course.year}-${course.semester}`
            this.$bvModal.show("scoreDetail");
        },
        toBack() {
            this.$router.push({name: "acadamicAffairSearchGradeMainPage"});
        }
    },
};
</script>

<style>
</style>