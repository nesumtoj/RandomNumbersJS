import { RandomNumbersAngularTemplatePage } from './app.po';

describe('RandomNumbersAngular App', function() {
  let page: RandomNumbersAngularTemplatePage;

  beforeEach(() => {
    page = new RandomNumbersAngularTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
