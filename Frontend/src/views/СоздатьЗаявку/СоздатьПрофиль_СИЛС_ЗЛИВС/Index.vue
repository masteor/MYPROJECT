  <template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
    v-divider
    v-card-text
      v-form(
        ref="form"
        v-model="valid"
      )
        //-- действующие ресурсы пользователя
        existent-resources-of-user(
          :existentResources="получитьДействующиеРесурсыПользователя"
          v-model="ДействующийОбъектРесурса"
        )

        //-- главные типы объектов
        main-types-of-objects(
          :main-types-of-objects="получитьГлавныеТипыОбъектов"
          v-model="ТипОбъектаРесурса"
        )

        //-- название типа сервиса
        name-of-type-of-service(
          :value="названиеТипаСервиса"
        )

        //-- название профиля
        name-of-profile(
          v-model="имяПрофиля"
          @blurProfile="blurProfile"
        )

        template(v-if="!еслиНазначаемПраваНаРесурс")
          //-- Тип добавляемого объекта (типы объектов сервисов)
          types-of-objects-of-services(
            :disabled="false/*еслиНазначаемПраваНаРесурс*/"
            :types-of-objects-of-services="получитьТипыОбъектовСервисов"
            :id-type-of-service="идТипаСервиса"
            v-model="ТипДобавляемогоОбъекта"
          )

          //-- название добавляемого объекта
          name-of-adding-object(
            :disabled="false/*еслиНазначаемПраваНаРесурс*/"
            v-model="названиеДобавляемогоОбъекта"
          )

        //-- права предоставляемые профилем
        rights-granted-by-profile(
          :rightsGrantedByProfile="отфильтрованныеПраваПредоставляемыеПрофилем"
          v-model="праваПредоставляемыеПрофилем"
          @selectDeselectRights="selectDeselectRights"
        )

        //-- дерево объектов c кнопками добавления/удаления объектов
        profile-tree(
          v-if="this.ДействующийОбъектРесурса !== null"
          :resource-name="имяРесурса"
          :items="treeFromArray"
          :showing-rights="$itemsCondition(получитьПраваПредоставляемыеПрофилем)"
          :type-of-object-of-resource="ТипОбъектаРесурса"
          :valid="можноЛиДобавитьОбъектКоПрофилю"
          @addObjectToProfile="addObjectToProfile($event)"
          @removeObject="removeObjectFromProfile($event)"
        )

    v-card-actions
      //-- кнопка отправить заявку
      v-btn(
        color="primary"
        :disabled="!(valid && объектыПрофиля.length > 0 && !profileExist)"
        shaped
        rounded
        :loading="loadingSendRequest"
        @click="SendRequestCreateProfile"
      ) Отправить заявку

      user-tools(
        @saveContent="saveContent"
        @clearContent="clearContent"
        @loadContent="loadContent"
      )
</template>

<script>
  // mixins
  import { vuexMixin } from '@/views/СоздатьЗаявку/СоздатьПрофиль_СИЛС_ЗЛИВС/js/vuex-mixin'
  import ОбъектыФормы, { ОбъектФормы } from './js/объектыФормы'
  import Watch from './js/watch'
  import Created from './js/created'
  import Computed from './js/computed'
  import ПроверкаИмениПрофиля from './js/other methods/проверкаИмениПрофиля'
  import MethodsRightsGranted from './js/other methods/rights-granted-by-profile'
  import Methods from './js/methods'
  import MethodsUserTools from './js/other methods/user-tools'
  import ОбъектыПрофиля from './js/other methods/объектыПрофиля/объектыПрофиля'

  // constants
  import { формаДобавленияОбъектовВПрофиль } from '@/constants/titles'

  // компоненты
  import UserTools from '@/components/UserTools'
  import ProfileTree from '@/components/v-treeview/ProfileTree'
  import ExistentResourcesOfUser from '@/components/v-autocomplete/ExistentResourcesOfUser'
  import MainTypesOfObjects from '@/components/v-autocomplete/MainTypesOfObjects'
  import RightsGrantedByProfile from '@/components/v-autocomplete/RightsGrantedByProfile'
  import TypesOfObjectsOfServices from '@/components/v-autocomplete/TypesOfObjectsOfServices'
  import ButtonsInCardActions from '@/views/СоздатьЗаявку/СоздатьПрофиль_СИЛС_ЗЛИВС/buttonsInCardActions'
  import NameOfTypeOfService from '@/components/v-text-field/NameOfTypeOfService'
  import NameOfProfile from '@/components/v-text-field/NameOfProfile'
  import NameOfAddingObject from '@/components/v-text-field/NameOfAddingObject'

  export default {
    name: 'CreateProfile',

    components: {
      NameOfAddingObject,
      NameOfProfile,
      NameOfTypeOfService,
      ButtonsInCardActions,
      TypesOfObjectsOfServices,
      RightsGrantedByProfile,
      MainTypesOfObjects,
      ExistentResourcesOfUser,
      ProfileTree,
      UserTools,
    },

    mixins: [
      vuexMixin,
      ОбъектыФормы,
      Watch,
      Created,
      Computed,
      ПроверкаИмениПрофиля,
      MethodsRightsGranted,
      Methods,
      MethodsUserTools,
      ОбъектыПрофиля,
    ],

    data: () => ({
      title: формаДобавленияОбъектовВПрофиль,
      stopWatching: false,
      valid: false,
      loadingSendRequest: false,
      i: null,
      объектПрофиля: null,

      // ----------------------------------------------
      //  Сохраняемые свойства в хранилище браузера
      // ----------------------------------------------
      /** @type {ОбъектФормы} */
      v: new ОбъектФормы(),
    }),
  }
</script>
