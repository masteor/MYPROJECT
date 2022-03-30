/* eslint-disable quotes */
import { ТипСервисов } from '@/store/param-types'

export function ВернутьВалидныйПример () {
  return new ТипСервисов(1, 'e', '', '', '', 0)
}

test('new ТипСервисов() бросает исключение', () => {
  expect(() => new ТипСервисов())
    .toThrowError(Error)
})

test(`new ТипСервисов(0, '', '', '', '', 0) бросает исключение`, () => {
  expect(() => new ТипСервисов(0, '', '', '', '', 0))
    .toThrowError(Error)
})

test(`валидный конструктор new ТипСервисов(1, 's') не бросает исключение`, () => {
  expect(() => new ТипСервисов(1, 'e', '', '', '', 0))
    .not.toThrowError(Error)
})
