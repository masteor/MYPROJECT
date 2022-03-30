import { shallowMount } from '@vue/test-utils'
import Component from '@/views/СоздатьЗаявку/ПредоставлениеДоступаКоРесурсу_СИЛС/Index.vue'

const wrapper = shallowMount(Component)

describe('Component', () => {
  /* it('wertyui', () => {
      expect(typeof Component.created).toBe('function')
  }) */

  it('xcvbnm', () => {
    expect(wrapper.vm.$data.v).toBe(undefined)
  })
})
