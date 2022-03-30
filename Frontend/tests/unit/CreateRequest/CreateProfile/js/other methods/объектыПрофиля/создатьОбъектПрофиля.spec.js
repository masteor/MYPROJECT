/*
// eslint-disable-next-line no-unused-vars
import { ОБЪЕКТ_ПРОФИЛЯ, ТипОбъектовСервисов, ТипСервисов } from '@/store/param-types'

test('ПроверитьИсоздатьОбъектПрофиля(undefined) бросает исключение', () => {
  expect(() => _.создатьОбъектПрофиля(undefined))
    .toThrowError(Error)
})

test('ПроверитьИсоздатьОбъектПрофиля(null) бросает исключение', () => {
  expect(() => _.создатьОбъектПрофиля(null))
    .toThrowError(Error)
})

test('ПроверитьИсоздатьОбъектПрофиля(new ТипПараметраСоздатьОбъектПрофиля()) - НЕ бросает исключение', () => {
  const param = new _.ТипПараметраСоздатьОбъектПрофиля()
  expect(() => _.создатьОбъектПрофиля(param)).toThrowError(Error)
})

test('ПроверитьИсоздатьОбъектПрофиля()', () => {
  const param = new _.ТипПараметраСоздатьОбъектПрофиля()
  param.id = -1
  expect(() => _.создатьОбъектПрофиля(param)).toThrowError(new Error(`id: ${param.id}`))
})

test('параметр: названиеДобавляемогоОбъекта?.length < 1', () => {
  const param = new _.ТипПараметраСоздатьОбъектПрофиля()
  param.id = 1
  param.названиеДобавляемогоОбъекта = ''
  expect(() => _.создатьОбъектПрофиля(param)).toThrowError(new Error('this.названиеДобавляемогоОбъекта?.length < 1'))
})

const валидныйТипСервисов = () => new ТипСервисов(1, 'q')
const валидныйТипОбъектовСервисов = () => new ТипОбъектовСервисов(
  1,
  'df',
  '2',
  0,
  валидныйТипСервисов(),
  'z',
  'x')

test('параметр: ТипДобавляемогоОбъекта?.id < 1', () => {
  const param = new _.ТипПараметраСоздатьОбъектПрофиля()
  param.ТипДобавляемогоОбъекта = валидныйТипОбъектовСервисов()
  expect(() => _.создатьОбъектПрофиля(param))
    .toThrowError(Error)
})

test('параметр: праваПредоставляемыеПрофилем?.length < 1', () => {
  const param = new _.ТипПараметраСоздатьОбъектПрофиля()
  param.id = 1
  param.названиеДобавляемогоОбъекта = 'q'
  param.ТипДобавляемогоОбъекта = new ТипОбъектовСервисов()
  param.ТипДобавляемогоОбъекта.id = 1
  param.праваПредоставляемыеПрофилем = []
  expect(() => _.создатьОбъектПрофиля(param))
    .toThrowError(new Error('this.праваПредоставляемыеПрофилем?.length < 1'))
})

test('СформироватьОбъектПрофиля из валидной модели', () => {
  const param = new _.ТипПараметраСоздатьОбъектПрофиля()
  param.id = 1
  param.названиеДобавляемогоОбъекта = 'q'
  param.ТипДобавляемогоОбъекта = new ТипОбъектовСервисов()
  param.ТипДобавляемогоОбъекта.id = 1
  param.праваПредоставляемыеПрофилем = [1]

  expect(_.СформироватьОбъектПрофиля(param))
    .toStrictEqual(
      new ОБЪЕКТ_ПРОФИЛЯ(
        param.id,
        null,
        null,
        param.названиеДобавляемогоОбъекта,
        param.ТипДобавляемогоОбъекта,
        [...param.праваПредоставляемыеПрофилем],
      ))
})

test('пустой конструктор ТипПараметраСоздатьОбъектПрофиля возвращает правильные свойства', () => {
  expect(new _.ТипПараметраСоздатьОбъектПрофиля())
    .toStrictEqual(new _.ТипПараметраСоздатьОбъектПрофиля(
      0, null, null, '', null, null))
})

test('_addObjectToProfile(undefined) бросает исключение', () => {
  expect(() => _._addObjectToProfile(undefined)).toThrowError(new Error('_addObjectToProfile(undefined)'))
})

test('_addObjectToProfile(null) бросает исключение', () => {
  expect(() => _._addObjectToProfile(null)).toThrowError(new Error('_addObjectToProfile(null)'))
})

test('вызываем конструктор Param() - бросает исключение', () => {
  expect(() => new _.Param())
    .toThrowError(new Error('Param.объектыПрофиля === null'))
})

test('вызываем конструктор Param(null, \'qw\') - бросает исключение', () => {
  const direction = 'qw'
  expect(() => new _.Param(null, direction))
    .toThrowError(new Error(`Param.direction: ${direction}`))
})

test('вызываем конструктор Param(null, null, null) - бросает исключение', () => {
  const direction = null
  expect(() => new _.Param(null, direction, null))
    .toThrowError(new Error('Param.объектыПрофиля === null'))
})

test('вызываем конструктор Param(null, null, [], \'\') - бросает исключение', () => {
  const direction = null
  expect(() => new _.Param(null, direction, [], ''))
    .toThrowError(new Error('Param.названиеДобавляемогоОбъекта.length < 1'))
})

test('вызываем конструктор Param(null, null, [], \'a\', null) - бросает исключение', () => {
  const direction = null
  expect(() => new _.Param(
    null,
    direction,
    [],
    'a',
    null,
  ))
    .toThrowError(new Error('Param.ТипДобавляемогоОбъекта === null'))
})

test('вызываем конструктор Param(null, null, [], \'a\', new ТипОбъектовСервисов()) - бросает исключение', () => {
  const direction = null
  expect(() => new _.Param(
    null,
    direction,
    [],
    'a',
    new ТипОбъектовСервисов(),
  ))
    .toThrowError(new Error('Param.ТипДобавляемогоОбъекта === null'))
})

test('валидный конструктор Param(null, null, [], \'a\', new ТипОбъектовСервисов()) - НЕ бросает исключение', () => {
  expect(() => new _.Param(
    null,
    null,
    [],
    'a',
    new ТипОбъектовСервисов(1, 'q', 2, 0, new ТипСервисов(1, 'qw'), 'v', 'p'),
    0,
  )).not.toThrowError(Error)
})

/!* if (this.active === undefined) throw new Error('Param.active === undefined')
if (this.direction !== 'child' && this.direction !== 'parent') throw new Error(`Param.direction: ${this.direction}`)
if (typeof this.объектыПрофиля === 'array') throw new Error(`typeof Param.объектыПрофиля должен быть массив`)
if (this.объектыПрофиля === null) throw new Error(`Param.объектыПрофиля === null`)
if (this.названиеДобавляемогоОбъекта.length < 1) throw new Error(`Param.названиеДобавляемогоОбъекта.length < 1`)
if (typeof this.ТипДобавляемогоОбъекта !== typeof ТипОбъектовСервисов) throw new Error(`typeof Param.ТипДобавляемогоОбъекта !== typeof ТипОбъектовСервисов`)
if (this.treeCounter < 0) throw new Error(`Param.treeCounter < 0`) *!/
*/
