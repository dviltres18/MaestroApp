import { MaestroAppTemplatePage } from './app.po';

describe('MaestroApp App', function() {
  let page: MaestroAppTemplatePage;

  beforeEach(() => {
    page = new MaestroAppTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
